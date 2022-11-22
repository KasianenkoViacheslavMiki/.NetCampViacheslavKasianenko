namespace HomeWork6_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountingEletricity accountingEletricity = new AccountingEletricity(3);
            //чому рік стрічкою?
            accountingEletricity.ReadFile(1, "2021");
            accountingEletricity.WriteFileInfoForUser();
            accountingEletricity.WriteFileAboutOneApartament(1);
            accountingEletricity.WriteConsoleAboutAllInfo();
            accountingEletricity.WriteFileAboutAllInfo();
        }
    }
}
