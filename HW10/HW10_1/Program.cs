using static HW10_1.Program;

namespace HW10_1
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                List<Triangle> triangles = new List<Triangle>
                {
                new Triangle(new Point(1,2), new Point(2,3), new Point (3, 15)),
                new Triangle(new Point(1, 2), new Point(1, 3), new Point(8, 15)),
                new Triangle(new Point(1, 9), new Point(2, 3), new Point(3, 15))
                };

                foreach (Triangle triangle in triangles)
                {
                    triangle.Print();

                }
                Triangle t = new Triangle(new Point(1, 9), new Point(1, 3), new Point(1, 15));

            }
            catch (ApplicationException ae) 
            {
                Console.WriteLine(ae.Message);
            }

           
        }
    }
}