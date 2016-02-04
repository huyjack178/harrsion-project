module Fanex.BetList.Core.ExcelUtils {
    export class ExcelUtils {

        public ExportExcel(htmlString: string): Element[][] {

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
        }

        private SendElementTableToServer(elements: Element[][]) {
            var elementTable = { Elements: elements };
            //$.ajax({
            //    type: "POST",
            //    url: "http://localhost:9697/Home/ExportExcel",
            //    data: { Elements: elements }
            //});

            $.post("http://localhost:9697/Home/ExportExcel", elementTable);
        }

        private CreateElementOfCell(htmlElements: any): Element {

            for (var id = 0; id < htmlElements.length; id++) {
                var htmlElement = htmlElements.get(id);
                var element = new Element(htmlElement);

                if (htmlElement.children.length != 0) {
                    element.Children = this.AddChildrenRecursive(element.Children, htmlElement);
                }

                return element;
            }
        }

        private AddChildrenRecursive(children: Array<Element>, child: any): Array<Element> {
            if (child.children.length == 0) {
                var element = new Element(child);
                children.push(element);
                return children;
            }

            else {
                var element = new Element(child);

                var subChildren = child.children;
                for (var i = 0; i < subChildren.length; i++) {
                    element.Children = new Array<Element>();
                    element.Children = this.AddChildrenRecursive(element.Children, subChildren[i]);
                    children.push(element);
                };

                return children;
            }
        }
    }


    export class Element {
        TagType: string
        Children: Array<Element>
        Text: string
        InLine: boolean
        Style: any

        constructor(htmlElement: HTMLElement) {
            this.Text = htmlElement.outerText;
            this.TagType = htmlElement.localName;
            this.Style = htmlElement.style;
            this.Children = new Array<Element>();
        }
    }

    export class Style {
        color: string
        font: string
    }
}

function ExportExcel(html: string) {
    var excelUtils = new Fanex.BetList.Core.ExcelUtils.ExcelUtils();
    excelUtils.ExportExcel(html);
}