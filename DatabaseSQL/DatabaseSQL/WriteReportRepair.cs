using System;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Microsoft.Data.SqlClient;


namespace DatabaseSQL
{
    internal class WriteReportRepair
    {
        public static void Write(string path)
        {
            int lineSize = 2;

            // Регистрация провайдера кодировки
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Создание экземпляра кодировки 1252
            Encoding encodingUTF8 = Encoding.UTF8;

            var document = new Document();

            var section = document.AddSection();

            #region head
            var paragraphHeadline2 = section.AddParagraph("Ремонт", encodingUTF8.ToString());
            paragraphHeadline2.Format.Alignment = ParagraphAlignment.Center;
            paragraphHeadline2.Format.Font.Size = 24;
            paragraphHeadline2.Format.Font.Name = "Arial";
            paragraphHeadline2.Format.Font.Underline = Underline.None;
            paragraphHeadline2.Format.Font.Color = Colors.Black;

            var paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "0.5cm"; // установка отступа сверху
            paragraph.Format.SpaceAfter = "0.5cm"; // установка отступа снизу
            paragraph.Format.Shading.Color = Colors.Black; // установка цвета фона
            paragraph.Format.Font.Size = lineSize;
            paragraph.AddLineBreak();
            #endregion head

            var listFlat = GetListFlat();

            foreach (var flat in listFlat)
            {
                var listOperationType = GetListOperationType(flat.Item1);
                var sumWork = 0.0;

                if (listOperationType.Count() == 0)
                    continue;

                #region Flat

                #region FlatInfo
                var tableFlat = new Table();
                section.Add(tableFlat);

                // Позиция таблицы

                // Удаление отступов между ячейками
                tableFlat.LeftPadding = 0;
                tableFlat.RightPadding = 0;
                tableFlat.TopPadding = 0;
                tableFlat.BottomPadding = 0;
                tableFlat.Rows.LeftIndent = 0;

                // Стиль таблицы
                // Устанавливаем стиль границ таблицы
                tableFlat.Style = "Table";
                // Формат таблицы
                tableFlat.Format.Alignment = ParagraphAlignment.Center;
                tableFlat.Rows.Alignment = RowAlignment.Center;

                // Ширина столбцов
                tableFlat.AddColumn((Unit)"6cm");
                tableFlat.AddColumn((Unit)"5cm");
                tableFlat.AddColumn((Unit)"4cm");
                tableFlat.AddColumn((Unit)"3cm");
                // Данные таблицы
                var rowTable = tableFlat.AddRow();
                rowTable.Height = Unit.FromCentimeter(1);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable.Cells[0].AddParagraph("Адрес");
                rowTable.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[1].AddParagraph("Владелец");
                rowTable.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[2].AddParagraph("Площадь");
                rowTable.Cells[2].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[3].AddParagraph("Жильцы");
                rowTable.Cells[3].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[3].Borders.Color = Colors.Black; // задаем цвет границ

                rowTable = tableFlat.AddRow();
                rowTable.Height = Unit.FromCentimeter(1);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable.Cells[0].AddParagraph(flat.Item2);
                rowTable.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[1].AddParagraph(flat.Item3);
                rowTable.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[2].AddParagraph(flat.Item4);
                rowTable.Cells[2].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[3].AddParagraph(flat.Item5);
                rowTable.Cells[3].Borders.Width = 0.5; // задаем толщину границ
                rowTable.Cells[3].Borders.Color = Colors.Black; // задаем цвет границ

                rowTable = tableFlat.AddRow();
                rowTable.Height = Unit.FromCentimeter(0.5);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable.Cells[0].AddParagraph();
                rowTable.Cells[0].MergeRight = 2;
                #endregion FlatInfo

                #region operationTypes
                foreach (var operationType in listOperationType)
                {
                    var listOperation = GetListOperation(flat.Item1, operationType.Item1);

                    var tableOperation = new Table();
                    section.Add(tableOperation);

                    // Позиция таблицы

                    // Удаление отступов между ячейками
                    tableOperation.LeftPadding = 0;
                    tableOperation.RightPadding = 0;
                    tableOperation.TopPadding = 0;
                    tableOperation.BottomPadding = 0;
                    tableOperation.Rows.LeftIndent = 0;

                    // Стиль таблицы
                    // Устанавливаем стиль границ таблицы
                    tableOperation.Style = "Table";
                    // Формат таблицы
                    tableOperation.Format.Alignment = ParagraphAlignment.Center;
                    tableOperation.Rows.Alignment = RowAlignment.Center;

                    // Ширина столбцов
                    tableOperation.AddColumn((Unit)"6cm");
                    tableOperation.AddColumn((Unit)"5cm");
                    tableOperation.AddColumn((Unit)"4cm");

                    rowTable = tableFlat.AddRow();
                    rowTable.Height = Unit.FromCentimeter(1);
                    rowTable.HeightRule = RowHeightRule.AtLeast;
                    rowTable.Cells[0].AddParagraph(operationType.Item2.ToString());
                    rowTable.Cells[0].MergeRight = 1;
                    rowTable.Cells[0].Borders.Width = 2; // задаем толщину границ
                    rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                    rowTable.Cells[2].AddParagraph(operationType.Item3.ToString());
                    rowTable.Cells[2].Borders.Width = 2; // задаем толщину границ
                    rowTable.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ

                    foreach (var operation in listOperation)
                    {
                        #region Operation
                        tableOperation = new Table();
                        section.Add(tableOperation);

                        // Позиция таблицы

                        // Удаление отступов между ячейками
                        tableOperation.LeftPadding = 0;
                        tableOperation.RightPadding = 0;
                        tableOperation.TopPadding = 0;
                        tableOperation.BottomPadding = 0;
                        tableOperation.Rows.LeftIndent = 0;

                        // Стиль таблицы
                        // Устанавливаем стиль границ таблицы
                        tableOperation.Style = "Table";
                        // Формат таблицы
                        tableOperation.Format.Alignment = ParagraphAlignment.Center;
                        tableOperation.Rows.Alignment = RowAlignment.Center;

                        // Ширина столбцов
                        tableOperation.AddColumn((Unit)"6cm");
                        tableOperation.AddColumn((Unit)"5cm");
                        tableOperation.AddColumn((Unit)"4cm");

                        rowTable = tableFlat.AddRow();
                        rowTable.Height = Unit.FromCentimeter(1);
                        rowTable.HeightRule = RowHeightRule.AtLeast;
                        rowTable.Cells[0].AddParagraph(operation.Item1.ToString());
                        rowTable.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                        rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                        rowTable.Cells[1].AddParagraph(operation.Item2.ToString());
                        rowTable.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                        rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                        rowTable.Cells[2].AddParagraph(operation.Item2.ToString());
                        rowTable.Cells[2].Borders.Width = 0.5; // задаем толщину границ
                        rowTable.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ

                        // Полсчёт суммы работ
                        sumWork += Convert.ToDouble(operationType.Item3);
                        #endregion Operation
                    }

                    tableOperation = new Table();
                    section.Add(tableOperation);

                    // Позиция таблицы

                    // Удаление отступов между ячейками
                    tableOperation.LeftPadding = 0;
                    tableOperation.RightPadding = 0;
                    tableOperation.TopPadding = 0;
                    tableOperation.BottomPadding = 0;
                    tableOperation.Rows.LeftIndent = 0;

                    // Стиль таблицы
                    // Устанавливаем стиль границ таблицы
                    tableOperation.Style = "Table";
                    // Формат таблицы
                    tableOperation.Format.Alignment = ParagraphAlignment.Center;
                    tableOperation.Rows.Alignment = RowAlignment.Center;

                    // Ширина столбцов
                    tableOperation.AddColumn((Unit)"6cm");
                    tableOperation.AddColumn((Unit)"5cm");
                    tableOperation.AddColumn((Unit)"4cm");

                    rowTable = tableFlat.AddRow();
                    rowTable.Height = Unit.FromCentimeter(1);
                    rowTable.HeightRule = RowHeightRule.AtLeast;
                    rowTable.Cells[0].AddParagraph("Количество работ");
                    rowTable.Cells[0].MergeRight = 1;
                    rowTable.Cells[0].Borders.Width = 1; // задаем толщину границ
                    rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                    rowTable.Cells[2].AddParagraph(listOperation.Count().ToString());
                    rowTable.Cells[2].Borders.Width = 1; // задаем толщину границ
                    rowTable.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ
                    rowTable = tableFlat.AddRow();
                    rowTable.Height = Unit.FromCentimeter(0.01);
                    rowTable.HeightRule = RowHeightRule.AtLeast;
                    rowTable.Cells[0].AddParagraph();
                    #endregion OperationTypes

                    #region Space
                    paragraph = section.AddParagraph();
                    paragraph.Format.SpaceBefore = "0.2cm"; // установка отступа сверху
                    paragraph.Format.SpaceAfter = "0.2cm"; // установка отступа снизу
                    paragraph.Format.Font.Size = 0.01;
                    paragraph.AddLineBreak();
                    #endregion Space
                }

                #region Sum
                var table = new Table();
                section.Add(table);

                // Позиция таблицы

                // Удаление отступов между ячейками
                table.LeftPadding = 0;
                table.RightPadding = 0;
                table.TopPadding = 0;
                table.BottomPadding = 0;
                table.Rows.LeftIndent = 0;

                // Стиль таблицы
                // Устанавливаем стиль границ таблицы
                table.Style = "Table";
                // Формат таблицы
                table.Format.Alignment = ParagraphAlignment.Center;
                table.Rows.Alignment = RowAlignment.Center;

                // Ширина столбцов
                table.AddColumn((Unit)"6cm");
                table.AddColumn((Unit)"5cm");

                rowTable = tableFlat.AddRow();
                rowTable.Height = Unit.FromCentimeter(1);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable = tableFlat.AddRow();
                rowTable.Height = Unit.FromCentimeter(1);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable.Cells[0].AddParagraph("Суммарная стоимость работ");
                rowTable.Cells[0].Borders.Width = 2; // задаем толщину границ
                rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[1].AddParagraph(sumWork.ToString());
                rowTable.Cells[1].Borders.Width = 2; // задаем толщину границ
                rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                #endregion Sum
                #endregion Flat

                #region endLine
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0.5cm"; // установка отступа сверху
                paragraph.Format.SpaceAfter = "0.5cm"; // установка отступа снизу
                paragraph.Format.Shading.Color = Colors.Black; // установка цвета фона
                paragraph.Format.Font.Size = lineSize;
                paragraph.AddLineBreak();
                #endregion endLine
            }

            #region saveReport
            // Сохранение документа
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path);
            #endregion saveReport
        }

        private static List<(int, string, string, string, string)> GetListFlat()
        {
            var listFlat = new List<(int, string, string, string, string)>();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = "Select tblFlat.intFlatId, tblFlat.txtFlatAddress,\n" +
                           "    (tblOwner.txtOwnerSurname + ' ' + tblOwner.txtOwnerName + ' ' + tblOwner.txtOwnerSecondName) as txtOwnerName,\n" +
                           "    tblFlat.fltArea, tblFlat.intCount\n" +
                           "From tblFlat inner join tblOwner on (tblFlat.intOwnerId = tblOwner.intOwnerId)";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                listFlat.Add(
                                (
                                    Convert.ToInt32(reader.GetValue(0)),
                                    reader.GetValue(1).ToString(),
                                    reader.GetValue(2).ToString(),
                                    reader.GetValue(3).ToString(), 
                                    reader.GetValue(4).ToString()
                                )
                              );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listFlat;
        }

        private static List<(int, string, string)> GetListOperationType(int intFlatId)
        {
            var listOperatioType = new List<(int, string, string)>();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = "Select DISTINCT tblOperationType.intOperationTypeId, tblOperationType.txtOperationTypeName, tblOperationType.fltOperationPrice\n" +
                           "From tblOperation inner join tblOperationType on(tblOperation.intOperationTypeId = tblOperationType.intOperationTypeId)\n" +
                           "Where(tblOperation.intFlatId = " + intFlatId.ToString() + ")";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                listOperatioType.Add(
                                (
                                    Convert.ToInt32(reader.GetValue(0)),
                                    reader.GetValue(1).ToString(),
                                    reader.GetValue(2).ToString()
                                )
                              );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listOperatioType;
        }

        private static List<(string, string, string)> GetListOperation(int intFlarId, int intTypeId)
        {
            var listOperation = new List<(string, string, string)>();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = "Select tblOperation.datOperationDate, tblOperation.txtOperationDescription,\n" +
                           "    (tblWorker.txtWorkerSurname + ' ' + tblWorker.txtWorkerName + ' ' + tblWorker.txtWorkerSecondName) as txtWorkerName\n" +
                           "From tblOperation, tblWorker\n" +
                           "Where(tblOperation.intFlatId = " + intFlarId.ToString() + " and tblOperation.intOperationTypeId = " + intTypeId.ToString() +
                           "    and tblOperation.intWorkerId = tblWorker.intWorkerId)";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                listOperation.Add(
                                (
                                    Convert.ToDateTime(reader.GetValue(0)).Day.ToString() + "." +
                                    Convert.ToDateTime(reader.GetValue(0)).Month.ToString() + "." +
                                    Convert.ToDateTime(reader.GetValue(0)).Year.ToString() + "\n",
                                    reader.GetValue(1).ToString(),
                                    reader.GetValue(2).ToString()
                                )
                              );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listOperation;
        }
    }
}
