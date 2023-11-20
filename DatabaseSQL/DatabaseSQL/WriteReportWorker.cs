using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Microsoft.Data.SqlClient;

namespace DatabaseSQL
{
   internal class WriteReportWorker
   {
        public static void Write(string path)
        {
            int lineSize = 1;
            // Регистрация провайдера кодировки
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Создание экземпляра кодировки 1252
            Encoding encodingUTF8 = Encoding.UTF8;

            var document = new Document();

            var section = document.AddSection();

            #region head
            var paragraphHeadline2 = section.AddParagraph("Рабочие", encodingUTF8.ToString());
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

            var listWorker = GetListWorker();

            foreach (var worker in listWorker)
            {
                #region Worker
                var tableWork = new Table();
                section.Add(tableWork);

                // Позиция таблицы

                // Удаление отступов между ячейками
                tableWork.LeftPadding = 0;
                tableWork.RightPadding = 0;
                tableWork.TopPadding = 0;
                tableWork.BottomPadding = 0;
                tableWork.Rows.LeftIndent = 0;

                // Стиль таблицы
                // Устанавливаем стиль границ таблицы
                tableWork.Style = "Table";
                // Формат таблицы
                tableWork.Format.Alignment = ParagraphAlignment.Center;
                tableWork.Format.Borders.Width = 0.5;
                tableWork.Format.Borders.Color = Colors.Black;
                tableWork.Rows.Alignment = RowAlignment.Center;

                // Ширина столбцов
                tableWork.AddColumn((Unit)"6cm");
                tableWork.AddColumn((Unit)"5cm");
                tableWork.AddColumn((Unit)"4cm");
                // Данные таблицы
                var rowWorker = tableWork.AddRow();
                rowWorker.Cells[0].AddParagraph(worker.Item2);
                rowWorker.Cells[1].AddParagraph(worker.Item3);
                rowWorker.Cells[2].AddParagraph(worker.Item4);
                #endregion Worker

                #region Space
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0.2cm"; // установка отступа сверху
                paragraph.Format.SpaceAfter = "0.2cm"; // установка отступа снизу
                paragraph.Format.Font.Size = 0.01;
                paragraph.AddLineBreak();
                #endregion Space

                #region TableWork
                #region headWorker
                var works = GetWork(worker.Item1);

                tableWork = new Table();
                section.Add(tableWork);

                // Удаление отступов между ячейками
                tableWork.LeftPadding = 0;
                tableWork.RightPadding = 0;
                tableWork.TopPadding = 0;
                tableWork.BottomPadding = 0;

                // Стиль таблицы
                // Устанавливаем стиль границ таблицы
                tableWork.Style = "Table";
                // Формат таблицы
                tableWork.Format.Alignment = ParagraphAlignment.Center;
                tableWork.Rows.Alignment = RowAlignment.Center;

                // Ширина столбцов
                tableWork.AddColumn((Unit)"5cm");
                tableWork.AddColumn((Unit)"4cm");
                tableWork.AddColumn((Unit)"2.5cm");
                tableWork.AddColumn((Unit)"1.5cm");

                // Заголовок
                rowWorker = tableWork.AddRow();
                rowWorker.Height = Unit.FromCentimeter(0.75);
                rowWorker.HeightRule = RowHeightRule.AtLeast;
                rowWorker.Cells[0].AddParagraph("Тип работ");
                rowWorker.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowWorker.Cells[1].AddParagraph("Адресс");
                rowWorker.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                rowWorker.Cells[2].AddParagraph("Дата");
                rowWorker.Cells[2].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ
                rowWorker.Cells[3].AddParagraph("Сумма");
                rowWorker.Cells[3].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[3].Borders.Color = Colors.Black; // задаем цвет границ
                #endregion headWorker

                foreach (var operation in works)
                {
                    #region Worker
                    // Данные таблицы
                    rowWorker = tableWork.AddRow();
                    rowWorker.Height = Unit.FromCentimeter(1);
                    rowWorker.HeightRule = RowHeightRule.AtLeast;
                    rowWorker.Cells[0].AddParagraph(operation.Item1); 
                    rowWorker.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                    rowWorker.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                    rowWorker.Cells[1].AddParagraph(operation.Item2);
                    rowWorker.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                    rowWorker.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                    rowWorker.Cells[2].AddParagraph(operation.Item3);
                    rowWorker.Cells[2].Borders.Width = 0.5; // задаем толщину границ
                    rowWorker.Cells[2].Borders.Color = Colors.Black; // задаем цвет границ
                    rowWorker.Cells[3].AddParagraph(operation.Item4);
                    rowWorker.Cells[3].Borders.Width = 0.5; // задаем толщину границ
                    rowWorker.Cells[3].Borders.Color = Colors.Black; // задаем цвет границ
                    #endregion Worker
                }

                #region Space
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0.2cm"; // установка отступа сверху
                paragraph.Format.SpaceAfter = "0.2cm"; // установка отступа снизу
                paragraph.Format.Font.Size = 0.01;
                paragraph.AddLineBreak();
                #endregion Space

                #region countWork
                var resultWorker = new Table();
                section.Add(resultWorker);

                // Удаление отступов между ячейками
                resultWorker.LeftPadding = 0;
                resultWorker.RightPadding = 0;
                resultWorker.TopPadding = 0;
                resultWorker.BottomPadding = 0;
                resultWorker.Rows.LeftIndent = 0;

                // Стиль таблицы
                // Устанавливаем стиль границ таблицы
                resultWorker.Style = "Table";
                // Формат таблицы
                resultWorker.Format.Alignment = ParagraphAlignment.Center;
                resultWorker.Rows.Alignment = RowAlignment.Center;

                // Ширина столбцов
                resultWorker.AddColumn((Unit)"5cm");
                resultWorker.AddColumn((Unit)"4cm");

                // Заголовок
                rowWorker = resultWorker.AddRow();
                rowWorker.Height = Unit.FromCentimeter(0.5);
                rowWorker.HeightRule = RowHeightRule.AtLeast;
                rowWorker.Cells[0].AddParagraph("Количество работ работ");
                rowWorker.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowWorker.Cells[1].AddParagraph("Сумма работ");
                rowWorker.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ

                rowWorker = resultWorker.AddRow();
                rowWorker.Height = Unit.FromCentimeter(0.5);
                rowWorker.HeightRule = RowHeightRule.AtLeast;
                rowWorker.Cells[0].AddParagraph(works.Count.ToString());
                rowWorker.Cells[0].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
                rowWorker.Cells[1].AddParagraph(worker.Item4.ToString());
                rowWorker.Cells[1].Borders.Width = 0.5; // задаем толщину границ
                rowWorker.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
                #endregion countWork

                #endregion TableWork

                #region endLine
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0.5cm"; // установка отступа сверху
                paragraph.Format.SpaceAfter = "0.5cm"; // установка отступа снизу
                paragraph.Format.Shading.Color = Colors.Black; // установка цвета фона
                paragraph.Format.Font.Size = lineSize;
                paragraph.AddLineBreak();
                #endregion endLine
            }

            #region endReport
            var resultTable = new Table();
            section.Add(resultTable);

            // Удаление отступов между ячейками
            resultTable.LeftPadding = 0;
            resultTable.RightPadding = 0;
            resultTable.TopPadding = 0;
            resultTable.BottomPadding = 0;
            resultTable.Rows.LeftIndent = 0;

            // Стиль таблицы
            // Устанавливаем стиль границ таблицы
            resultTable.Style = "Table";
            // Формат таблицы
            resultTable.Format.Alignment = ParagraphAlignment.Center;
            resultTable.Rows.Alignment = RowAlignment.Center;

            // Ширина столбцов
            resultTable.AddColumn((Unit)"5cm");
            resultTable.AddColumn((Unit)"4cm");

            // Заголовок
            var countWorker = resultTable.AddRow();
            countWorker.Height = Unit.FromCentimeter(0.5);
            countWorker.HeightRule = RowHeightRule.AtLeast;
            countWorker.Cells[0].AddParagraph("Всего рабочих");
            countWorker.Cells[0].Borders.Width = 0.5; // задаем толщину границ
            countWorker.Cells[0].Borders.Color = Colors.Black; // задаем цвет границ
            countWorker.Cells[1].AddParagraph(listWorker.Count.ToString());
            countWorker.Cells[1].Borders.Width = 0.5; // задаем толщину границ
            countWorker.Cells[1].Borders.Color = Colors.Black; // задаем цвет границ
            #endregion endReport

            #region saveReport
            // Сохранение документа
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(path);
            #endregion saveReport
        }

        private static List<(int, string, string, string)> GetListWorker()
        {
            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = "Select intWorkerId, (txtWorkerSurname + ' ' + txtWorkerName + ' ' + txtWorkerSecondName) as txtWorkerName,\n" +
                           "    txtWorkerSpecialist, fltSum\n" + 
                           "    From tblWorker";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            var listWorker = new List<(int, string, string, string)>();

            while (reader.Read())
                listWorker.Add(
                                (
                                    Convert.ToInt32(reader.GetValue(0)),
                                    reader.GetValue(1).ToString(),
                                    reader.GetValue(2).ToString(),
                                    reader.GetValue(3).ToString()
                                )
                              );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listWorker;
        }

        private static List<(string, string, string, string)> GetWork(int intWorkerId)
        {
            DataBaseFlats.dataBaseFlats.OpenConnection();

            string query = 
                "Select tblOperationType.txtOperationTypeName, tblFlat.txtFlatAddress, tblOperation.datOperationDate, tblOperationType.fltOperationPrice " +
                "From tblOperation inner join tblOperationType on(tblOperation.intOperationTypeId = tblOperationType.intOperationTypeId)" +
                "inner join tblFlat on(tblOperation.intFlatId = tblFlat.intFlatId)" +
                "Where(tblOperation.intWorkerId = " + intWorkerId.ToString() + ")";


            var slqCommand = new SqlCommand(query, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            var listWork = new List<(string, string, string, string)>();

            while (reader.Read())
                listWork.Add(
                                (
                                    reader.GetValue(0).ToString(),
                                    reader.GetValue(1).ToString(),
                                    Convert.ToDateTime(reader.GetValue(2)).Day.ToString() + "." +
                                    Convert.ToDateTime(reader.GetValue(2)).Month.ToString() + "." +
                                    Convert.ToDateTime(reader.GetValue(2)).Year.ToString() + "\n",
                                    reader.GetValue(3).ToString()
                                )
                              );

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return listWork;
        }
   }
}
