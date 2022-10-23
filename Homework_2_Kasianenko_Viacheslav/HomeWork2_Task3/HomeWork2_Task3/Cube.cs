using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task3
{
    internal class Cube
    {
        //Field
        private int[,,] cube3D;

        //Constructor

        //Construstor for manual init. cube.
        public Cube(int[,,] cube3D)
        {
            this.cube3D = cube3D;
        }

        //Constructor for randomize fill cube.
        public Cube (int widthCube, int heightCube, int depthCube)
        {
            Random random = new Random();
            this.cube3D = new int[widthCube, heightCube, depthCube];
            for (int x = 0; x < widthCube; x++)
            {
                for (int y = 0; y < heightCube; y++)
                {
                    for (int z = 0; z < depthCube; z++)
                    {
                        cube3D[x,y,z]=random.Next(0,2);
                    }
                }
            }
        }

        //Method

        //Method for check cube does it`s have hole.
        public bool isHaveHole()
        {
            for (int y = 0; y < cube3D.GetLength(1); y++)
            {
                for (int z = 0; z < cube3D.GetLength(2); z++)
                {
                    if (cube3D[0, y, z] == 0)
                    {
                        int x = 0;
                        while (cube3D[x, y, z] == 0)
                        {
                            x++;
                            if (x == cube3D.GetLength(0))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            for (int x = 0; x < cube3D.GetLength(0); x++)
            {
                for (int y = 0; y < cube3D.GetLength(1); y++)
                {
                    if (cube3D[x, y, 0] == 0)
                    {
                        int z = 0;
                        while (cube3D[x, y, z] == 0)
                        {
                            z++;
                            if (x == cube3D.GetLength(2))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            for (int x = 0; x < cube3D.GetLength(0); x++)
            {
                for (int z = 0; z < cube3D.GetLength(2); z++)
                {
                    if (cube3D[x, 0, z] == 0)
                    {
                        int y = 0;
                        while (cube3D[x, y, z] == 0)
                        {
                            y++;
                            if (x == cube3D.GetLength(1))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (int x = 0; x < cube3D.GetLength(0); x++)
            {
                for (int y = 0; y < cube3D.GetLength(1); y++)
                {
                    for (int z = 0; z < cube3D.GetLength(2); z++)
                    {
                        result+=cube3D[x,y,z]+" ";
                    }
                    result += "\n";
                }
                result += "\n\n";
            }
            return result;
        }
    }
}
