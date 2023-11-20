using Microsoft.Data.SqlClient;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Text;


namespace DatabaseSQL
{
    internal class WriteReportOperation
    {
        public static void Write(string path, int typeWork)
        {
            double lineSize = 1.5;
            // Регистрация провайдера кодировки
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Создание экземпляра кодировки 1252
            Encoding encodingUTF8 = Encoding.UTF8;

            var document = new Document();

            var section = document.AddSection();

            var typeWorkInfo = GetTypeWorkInfo(typeWork);

            #region head
            var paragraphHeadline2 = section.AddParagraph("Работа", encodingUTF8.ToString());
            paragraphHeadline2.Format.Alignment = ParagraphAlignment.Center;
            paragraphHeadline2.Format.Font.Size = 24;
            paragraphHeadline2.Format.Font.Name = "Arial";
            paragraphHeadline2.Format.Font.Underline = Underline.None;
            paragraphHeadline2.Format.Font.Color = Colors.Black;

            #region TableTypeWorkInfo
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
            table.AddColumn((Unit)"8cm");
            table.AddColumn((Unit)"8cm");
            // Данные таблицы
            var rowTable = table.AddRow();
            rowTable.Height = Unit.FromCentimeter(0.75);
            rowTable.HeightRule = RowHeightRule.AtLeast;
            rowTable.Cells[0].AddParagraph(typeWorkInfo.Item1);
            rowTable.Cells[0].Borders.Width = lineSize; // задаем толщину границ
            rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
            rowTable.Cells[1].AddParagraph(typeWorkInfo.Item2);
            rowTable.Cells[1].Borders.Width = lineSize; // задаем толщину границ
            rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
            #endregion TableTypeWorkInfo

            var paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "0.5cm"; // установка отступа сверху
            paragraph.Format.SpaceAfter = "0.5cm"; // установка отступа снизу
            paragraph.Format.Shading.Color = Colors.Black; // установка цвета фона
            paragraph.Format.Font.Size = lineSize;
            paragraph.AddLineBreak();
            #endregion head

            var listWorkerOperate = GetWorkerOperate(typeWork);

            #region listWorker
            foreach (var worker in listWorkerOperate)
            {
                #region Worker
                table = new Table();
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
                table.AddColumn((Unit)"8cm");
                table.AddColumn((Unit)"8cm");
                // Данные таблицы
                rowTable = table.AddRow();
                rowTable.Height = Unit.FromCentimeter(0.75);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable.Cells[0].AddParagraph(worker.Item2);
                rowTable.Cells[0].Borders.Width = lineSize - 0.25; // задаем толщину границ
                rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowTable.Cells[1].AddParagraph(worker.Item3);
                rowTable.Cells[1].Borders.Width = lineSize - 0.25; // задаем толщину границ
                rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                #endregion Worker

                var listOperation = GetOperate(typeWork, worker.Item1);

                #region headListOperation
                table = new Table();
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
                table.AddColumn((Unit)"8cm");
                table.AddColumn((Unit)"2.5cm");
                table.AddColumn((Unit)"4.5cm");
                #endregion headListOperation

                #region rowsListOperation
                foreach (var operation in listOperation)
                {
                    // Данные таблицы
                    rowTable = table.AddRow();
                    rowTable.Height = Unit.FromCentimeter(0.75);
                    rowTable.HeightRule = RowHeightRule.AtLeast;
                    rowTable.Cells[0].AddParagraph(operation.Item1);
                    rowTable.Cells[0].Borders.Width = lineSize - 1; // задаем толщину границ
                    rowTable.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                    rowTable.Cells[1].AddParagraph(operation.Item2);
                    rowTable.Cells[1].Borders.Width = lineSize - 1; // задаем толщину границ
                    rowTable.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                    rowTable.Cells[2].AddParagraph(operation.Item3);
                    rowTable.Cells[2].Borders.Width = lineSize - 1; // задаем толщину границ
                    rowTable.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ
                }
                rowTable = table.AddRow();
                rowTable.Height = Unit.FromCentimeter(0.25);
                rowTable.HeightRule = RowHeightRule.AtLeast;
                rowTable.Cells[0].AddParagraph();
                #endregion rowsListOperation
            }
            #endregion listWorker

            #region saveReport
            // Сохранение документа
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path);
            #endregion saveReport
        }

        private static (string, string) GetTypeWorkInfo(int typeWork)
        {
            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query =
                "Select txtOperationTypeName, fltOperationPrice\n" +
                "From tblOperationType\n" +
                "Where(intOperationTypeId = " + typeWork.ToString() + ")";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            (string, string) workInfo = (null, null);

            while (reader.Read())
                workInfo = (
                                reader.GetValue(0).ToString(),
                                reader.GetValue(1).ToString()
                           );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return workInfo;
        }

        private static List<(int, string, string)> GetWorkerOperate(int typeWork)
        {
            var listWorkerOperation = new List<(int, string, string)>();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query =
                "Select Distinct tblOperation.intWorkerId, (tblWorker.txtWorkerSurname + ' ' + tblWorker.txtWorkerName + ' ' + tblWorker.txtWorkerSecondName)\n" +
                "   as txtWorkerName, tblWorker.txtWorkerSpecialist\n" +
                "From tblWorker inner join tblOperation on(tblWorker.intWorkerId = tblOperation.intWorkerId)\n" +
                "Where(tblOperation.intOperationTypeId = " + typeWork.ToString() + ")";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                listWorkerOperation.Add
                            (   
                                (
                                Convert.ToInt32(reader.GetValue(0)),
                                reader.GetValue(1).ToString(),
                                reader.GetValue(2).ToString()
                                )
                            );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listWorkerOperation;
        }

        private static List<(string, string, string)> GetOperate(int typeWork, int intWorkerId)
        {
            var listOperation = new List<(string, string, string)>();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query =
                "Select tblFlat.txtFlatAddress, tblOperation.datOperationDate, tblOperation.txtOperationDescription\n" +
                "From tblOperation inner join tblFlat on(tblOperation.intFlatId = tblFlat.intFlatId)\n" +
                "Where(tblOperation.intOperationTypeId = " + typeWork.ToString() + " and tblOperation.intWorkerId = " + intWorkerId.ToString() + ")\n" +
                "Order by tblOperation.datOperationDate";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                listOperation.Add
                            (
                                (
                                reader.GetValue(0).ToString(),
                                Convert.ToDateTime(reader.GetValue(1)).Day.ToString() + "." +
                                Convert.ToDateTime(reader.GetValue(1)).Month.ToString() + "." +
                                Convert.ToDateTime(reader.GetValue(1)).Year.ToString(),
                                reader.GetValue(2).ToString()
                                )
                            );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listOperation;
        }
    }
}
