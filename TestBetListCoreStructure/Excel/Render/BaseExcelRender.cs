using Excel.Entity;
using Excel.Helper;
using Excel.Util;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;

namespace Excel.Render
{
    public class BaseExcelRender
    {
        /// <summary>
        /// The workbook.
        /// </summary>
        private IWorkbook _workbook;

        /// <summary>
        /// The report columns number.
        /// </summary>
        private short _reportColumnsNum;

        /// <summary>
        /// The worksheet.
        /// </summary>
        private ISheet _worksheet;

        private bool _isDisposed;

        /// <summary>
        /// Index of the next cell in current row.
        /// </summary>
        private int _nextCellIndex;

        public BaseExcelRender()
        {
            _workbook = new HSSFWorkbook();

            _isDisposed = false;

            OddCellStyle = _workbook.CreateCellStyle();
            EvenCellStyle = _workbook.CreateCellStyle();
            OddCellStyleCenterAligned = _workbook.CreateCellStyle();
            EvenCellStyleCenterAligned = _workbook.CreateCellStyle();

            _nextCellIndex = -1;

            RTFHelper = new RTFHelper()
            {
                NegFont = _workbook.CreateFont(),
                NormalFont = _workbook.CreateFont(),
                PosFont = _workbook.CreateFont(),
                NegFontCrossed = _workbook.CreateFont(),
                NormalFontCrossed = _workbook.CreateFont(),
                PosFontCrossed = _workbook.CreateFont(),
                RTFRenderer = new RtfTextRender()
            };

            InitDefaultRTFHelper();
            InitDefaultCellStyles();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the odd cell style.
        /// </summary>
        /// <value>The odd cell style.</value>
        public ICellStyle OddCellStyle { get; set; }

        /// <summary>
        /// Gets or sets the even cell style.
        /// </summary>
        /// <value>The even cell style.</value>
        public ICellStyle EvenCellStyle { get; set; }

        /// <summary>
        /// Gets or sets the odd cell style center aligned.
        /// </summary>
        /// <value>The odd cell style center aligned.</value>
        public ICellStyle OddCellStyleCenterAligned { get; set; }

        /// <summary>
        /// Gets or sets the even cell style center aligned.
        /// </summary>
        /// <value>The even cell style center aligned.</value>
        public ICellStyle EvenCellStyleCenterAligned { get; set; }

        /// <summary>
        /// Gets or sets the RTF helper.
        /// </summary>
        /// <value>The RTF helper.</value>
        public RTFHelper RTFHelper { get; set; }

        /// <summary>
        /// Gets the last content row.
        /// </summary>
        /// <value>The last content row.</value>
        public int LastContentRow
        {
            get
            {
                return _worksheet.LastRowNum;
            }
        }

        #endregion Properties

        private void InitDefaultRTFHelper()
        {
            RTFHelper.PosFont.Boldweight = RTFHelper.PosFontCrossed.Boldweight = (short)FontBoldWeight.Bold;
            RTFHelper.NegFont.Boldweight = RTFHelper.NegFontCrossed.Boldweight = (short)FontBoldWeight.Bold;
            RTFHelper.NormalFont.Boldweight = RTFHelper.NormalFontCrossed.Boldweight = (short)FontBoldWeight.Normal;

            RTFHelper.NegFont.FontName = RTFHelper.NegFontCrossed.FontName = RTFHelper.NormalFont.FontName = "Tahoma";
            RTFHelper.NormalFontCrossed.FontName = RTFHelper.PosFont.FontName = RTFHelper.PosFontCrossed.FontName = "Tahoma";

            RTFHelper.NegFont.FontHeightInPoints = RTFHelper.NegFontCrossed.FontHeightInPoints = RTFHelper.NormalFont.FontHeightInPoints = 9;
            RTFHelper.NormalFontCrossed.FontHeightInPoints = RTFHelper.PosFont.FontHeightInPoints = RTFHelper.PosFontCrossed.FontHeightInPoints = 9;

            RTFHelper.NormalFontCrossed.IsStrikeout = RTFHelper.PosFontCrossed.IsStrikeout = RTFHelper.NegFontCrossed.IsStrikeout = true;

            RTFHelper.NegFont.Color = RTFHelper.NegFontCrossed.Color = IndexedColors.Red.Index;
        }

        private void InitDefaultCellStyles()
        {
            OddCellStyle.Alignment = EvenCellStyle.Alignment = HorizontalAlignment.Right;

            // There's probably a bug in the VerticalAlignment enum of NPOI 2.0.6.0,
            // where VerticalAlignment.Top is actually resulting in middle alignment,
            // and VerticalAlignment.Bottom is in fact top alignment.
            OddCellStyle.VerticalAlignment = EvenCellStyle.VerticalAlignment = VerticalAlignment.Bottom;
            OddCellStyle.FillPattern = EvenCellStyle.FillPattern = FillPattern.SolidForeground;

            OddCellStyle.BorderTop = OddCellStyle.BorderRight = OddCellStyle.BorderBottom = OddCellStyle.BorderLeft = BorderStyle.Thin;
            EvenCellStyle.BorderTop = EvenCellStyle.BorderRight = EvenCellStyle.BorderBottom = EvenCellStyle.BorderLeft = BorderStyle.Thin;

            OddCellStyle.TopBorderColor = OddCellStyle.RightBorderColor = OddCellStyle.BottomBorderColor = OddCellStyle.LeftBorderColor = 54;
            EvenCellStyle.TopBorderColor = EvenCellStyle.RightBorderColor = EvenCellStyle.BottomBorderColor = EvenCellStyle.LeftBorderColor = 54;

            OddCellStyle.FillForegroundColor = 26;
            OddCellStyle.FillBackgroundColor = 43;

            EvenCellStyle.FillForegroundColor = 9;
            EvenCellStyle.FillBackgroundColor = 27;

            OddCellStyle.SetFont(RTFHelper.NormalFont);
            EvenCellStyle.SetFont(RTFHelper.NormalFont);

            OddCellStyleCenterAligned.CloneStyleFrom(OddCellStyle);
            OddCellStyleCenterAligned.Alignment = HorizontalAlignment.Center;
            OddCellStyleCenterAligned.SetFont(RTFHelper.NormalFont);

            EvenCellStyleCenterAligned.CloneStyleFrom(EvenCellStyle);
            EvenCellStyleCenterAligned.Alignment = HorizontalAlignment.Center;
            EvenCellStyleCenterAligned.SetFont(RTFHelper.NormalFont);

            // For line-breaks in MS Office
            OddCellStyle.WrapText = true;
            EvenCellStyle.WrapText = true;
            EvenCellStyleCenterAligned.WrapText = true;
            OddCellStyleCenterAligned.WrapText = true;
        }

        public BaseExcelRender BuildWorksheet(string sheetName, short numberOfColumns, short singleRowHeight = 13, bool displayGridlines = false)
        {
            _worksheet = _workbook.CreateSheet(sheetName);
            _worksheet.DisplayGridlines = displayGridlines;
            _worksheet.DefaultRowHeight = singleRowHeight;
            _reportColumnsNum = numberOfColumns;
            return this;
        }

        public IWorkbook GetBetList()
        {
            AdaptRowHeight();
            return _workbook;
        }

        private void AdaptRowHeight()
        {
            IEnumerator rowEnum = _worksheet.GetRowEnumerator();

            while (rowEnum.MoveNext())
            {
                IRow currentRow = rowEnum.Current as HSSFRow;
                int totalLineBreaks = 0;
                foreach (ICell cell in currentRow.Cells)
                {
                    totalLineBreaks = Math.Max(totalLineBreaks, cell.StringCellValue.GetLineBreakTotal());
                }

                currentRow.HeightInPoints = totalLineBreaks * _worksheet.DefaultRowHeight;
            }
        }

        public static BetListExcelBuilder AddNo(this BetListExcelBuilder factory, int index)
        {
            IRichTextString rtfNo = new HSSFRichTextString(index.ToString());
            factory.AddCell(rtfNo);
            return factory;
        }

        public CellAddress AddCell(IRichTextString rtfString)
        {
            _nextCellIndex++;
            IRow lastRow = GetLastRow();

            if (_nextCellIndex >= _reportColumnsNum)
            {
                _nextCellIndex = 0;
            }

            ICell lastCell;

            if (lastRow.RowNum % 2 == 0)
            {
                lastCell = lastRow.CreateCell(_nextCellIndex, EvenCellStyle);
            }
            else
            {
                lastCell = lastRow.CreateCell(_nextCellIndex, OddCellStyle);
            }

            lastCell.SetCellValue(rtfString);

            return new CellAddress(lastCell.RowIndex, _nextCellIndex);
        }

        private IRow GetLastRow()
        {
            IRow lastRow = _worksheet.GetRow(_worksheet.LastRowNum);
            if (lastRow == null || lastRow.Cells.Count == _reportColumnsNum || _nextCellIndex >= _reportColumnsNum)
            {
                lastRow = AddNewRow();
            }

            return lastRow;
        }

        private IRow AddNewRow()
        {
            int newRowIndex = _worksheet.LastRowNum;

            if (IsSheetHasRows())
            {
                newRowIndex += 1;
            }

            IRow newRow = _worksheet.CreateRow(newRowIndex);
            return newRow;
        }

        private bool IsSheetHasRows()
        {
            return _worksheet.GetRow(_worksheet.LastRowNum) != null;
        }
    }
}
