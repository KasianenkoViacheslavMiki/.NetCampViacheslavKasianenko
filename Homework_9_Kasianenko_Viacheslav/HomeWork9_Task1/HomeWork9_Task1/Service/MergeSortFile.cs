using HomeWork9_Task1.Interface;
using HomeWork9_Task1.Model;

namespace HomeWork9_Task1.Service
{
    public partial class MergeSortFile
    {
        private List<string> InitSort(string path) //Одна функція яка виконує по шагово зчитування і сортує методом Merge та й зразу же записує його в файл для звільнення пам'яті
        {
            IParseStrArrToIntArr parseStringArrayToIntArray = new Parse();
            List<string> result=new List<string>();

            string line;
            string[] stringData;
            int[] intData;
            int intNameFile = 1;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    stringData = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    intData = parseStringArrayToIntArray.ParseStringArrayToIntArray(stringData);
                    MergeSort.MergeSortFunc(ref intData);
                    ActionFile.ArrayToFile(intData, intNameFile.ToString()+".txt");
                    result.Add(intNameFile.ToString() + ".txt");
                    intNameFile++;
                }
                sr.Close();
            }
            return result;
        }
        private void MergeFiles(string outputPath, List<string> stringsNameFile)
        {
            string value="";
            int l;
            List<StreamReader> streamReaders = new List<StreamReader>();    
            foreach (string file in stringsNameFile) 
            { 
                streamReaders.Add(new StreamReader(file));
            }
            ArrayCell numberInput = new ArrayCell(stringsNameFile.Count);
            using (StreamWriter streamWriter = new StreamWriter(outputPath,false))
            {
                int i; int p;
                for (i = 0; i < numberInput.GetLength(); i++)
                {
                    value = "";
                    while ((l = streamReaders[i].Read()) != ' ' && l !=-1) value += (char)l;
                    if (!Int32.TryParse(value,out p)) throw new Exception("Error parse");
                    numberInput[i].element = p;
                    numberInput[i].fileNumber = i;
                }
                int count = 0;
                Cell min=new Cell();
                while (count != i)
                {
                    value = "";
                    min = numberInput.FindMin();
                    streamWriter.Write(min.element+" ");

                    while ((l = streamReaders[min.fileNumber].Read()) != ' ' && l != -1)
                    {
                        if ((char)l == '\r')
                        {
                            count++;
                        }
                        value += (char)l;
                    }
                    if (value == "\r\n") value = Int32.MaxValue.ToString();
                    
                    if (!Int32.TryParse(value, out p)) throw new Exception("Error parse");
                    numberInput[min.fileNumber].element = p;
                }
                streamWriter.Close();
            }
            foreach (var item in streamReaders) item.Close();
        }
        public void ExternalSort(string inputPath= "input.txt", string outputPath= "RESULT.txt")
        {
            List<string> stringsNameFile = this.InitSort(inputPath);
            MergeFiles(outputPath, stringsNameFile);
        }
    }
}
