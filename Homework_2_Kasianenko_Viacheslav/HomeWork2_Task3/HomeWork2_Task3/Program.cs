namespace HomeWork2_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cube cube = new Cube(new int[3,3 ,3 ] { 
                                                 { 
                                                   { 1, 0, 1 }, 
                                                   { 1, 1, 2 }, 
                                                   { 1, 1, 2 } 
                                                                },
                                                  
                                                 { 
                                                    { 1, 0, 2 }, 
                                                    { 1, 1, 1 }, 
                                                    { 2, 2, 1 } 
                                                                 },
                                                 { 
                                                    { 2, 0, 1 }, 
                                                    { 2, 1, 2 }, 
                                                    { 2, 1, 1 } 
                                                                 }
                                                                  });
            Console.WriteLine(cube.isHaveHole() ? "Yes,it`s have hole" : "No, it`s not have hole");
            Console.WriteLine("Hello, World!");
        }
    }
}