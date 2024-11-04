namespace FileWriter_Test_Pattern_Finalize
{
    class FileWriter : IDisposable
    {
        private FileStream fileStream;
        private bool disposed = false;

        public FileWriter(string filePath)
        {
            // Открываем файл для записи
            fileStream = new FileStream(filePath, FileMode.Create);
        }

        public void WriteData(string data)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FileWriter));

            // Записываем данные в файл
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            fileStream.Write(bytes, 0, bytes.Length);
        }

        // Метод Dispose вызывается для ручного освобождения ресурсов
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Отключает вызов Finalize для этого объекта
        }

        // Основная логика освобождения ресурсов
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    fileStream?.Dispose();
                }

                // Освобождаем неуправляемые ресурсы (если есть)
                disposed = true;
            }
        }

        // Метод Finalize для вызова Dispose(false), если Dispose не был вызван вручную
        ~FileWriter()
        {
            Dispose(false);
        }
    }
}