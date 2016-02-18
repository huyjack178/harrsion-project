using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Util
{
    public static class ICellExtension
    {
        public static void SetCellValue(this ICell cell, object value)
        {
            if (value == null)
            {
                cell.SetCellValue("0");
            }
            else
            {
                if (value is string)
                {
                    // cell.SetCellValue(value);
                    cell.SetCellValue((string)value);
                }
                else if (value is int)
                {
                    cell.SetCellValue((int)value);
                }
                else if (value is long)
                {
                    cell.SetCellValue((long)value);
                }
                else if (value is double)
                {
                    cell.SetCellValue((double)value);
                }
                else if (value is decimal)
                {
                    cell.SetCellValue((decimal)value);
                }
                else if (value is bool)
                {
                    cell.SetCellValue((bool)value);
                }
                else if (value is DateTime)
                {
                    cell.SetCellValue((DateTime)value);
                }
                else if (value is IRichTextString)
                {
                    cell.SetCellValue((IRichTextString)value);

                    // cell.SetCellValue(value);
                }
                else
                {
                    cell.SetCellValue("Undefined");
                }
            }
        }
    }
}
