var Fanex;
(function (Fanex) {
    var BetList;
    (function (BetList) {
        var Core;
        (function (Core) {
            var ExcelUtils;
            (function (ExcelUtils_1) {
                var ExcelUtils = (function () {
                    function ExcelUtils() {
                    }
                    ExcelUtils.prototype.ExportExcel = function (htmlString) {
                        var elementTable = [[], []];
                        var rows = jQuery(htmlString).find("tr");
                        for (var rowId = 0; rowId < rows.length; rowId++) {
                            var cols = jQuery(rows.get(rowId)).find("td");
                            for (var colId = 0; colId < cols.length; colId++) {
                                var htmlElements = jQuery(cols.get(colId)).children("*");
                                elementTable[rowId][colId] = this.CreateElementOfCell(htmlElements);
                            }
                        }
                        console.log(elementTable);
                        this.SendElementTableToServer(elementTable);
                        return elementTable;
                    };
                    ExcelUtils.prototype.SendElementTableToServer = function (elements) {
                        var elementTable = { Elements: elements };
                        //$.ajax({
                        //    type: "POST",
                        //    url: "http://localhost:9697/Home/ExportExcel",
                        //    data: { Elements: elements }
                        //});
                        $.post("http://localhost:9697/Home/ExportExcel", elementTable);
                    };
                    ExcelUtils.prototype.CreateElementOfCell = function (htmlElements) {
                        for (var id = 0; id < htmlElements.length; id++) {
                            var htmlElement = htmlElements.get(id);
                            var element = new Element(htmlElement);
                            if (htmlElement.children.length != 0) {
                                element.Children = this.AddChildrenRecursive(element.Children, htmlElement);
                            }
                            return element;
                        }
                    };
                    ExcelUtils.prototype.AddChildrenRecursive = function (children, child) {
                        if (child.children.length == 0) {
                            var element = new Element(child);
                            children.push(element);
                            return children;
                        }
                        else {
                            var element = new Element(child);
                            var subChildren = child.children;
                            for (var i = 0; i < subChildren.length; i++) {
                                element.Children = new Array();
                                element.Children = this.AddChildrenRecursive(element.Children, subChildren[i]);
                                children.push(element);
                            }
                            ;
                            return children;
                        }
                    };
                    return ExcelUtils;
                })();
                ExcelUtils_1.ExcelUtils = ExcelUtils;
                var Element = (function () {
                    function Element(htmlElement) {
                        this.Text = htmlElement.outerText;
                        this.TagType = htmlElement.localName;
                        this.Style = htmlElement.style;
                        this.Children = new Array();
                    }
                    return Element;
                })();
                ExcelUtils_1.Element = Element;
                var Style = (function () {
                    function Style() {
                    }
                    return Style;
                })();
                ExcelUtils_1.Style = Style;
            })(ExcelUtils = Core.ExcelUtils || (Core.ExcelUtils = {}));
        })(Core = BetList.Core || (BetList.Core = {}));
    })(BetList = Fanex.BetList || (Fanex.BetList = {}));
})(Fanex || (Fanex = {}));
function ExportExcel(html) {
    var excelUtils = new Fanex.BetList.Core.ExcelUtils.ExcelUtils();
    excelUtils.ExportExcel(html);
}
//# sourceMappingURL=Fanex.BetList.Core.ExcelUtil.js.map