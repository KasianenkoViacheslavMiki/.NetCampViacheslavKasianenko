using HomeWork9_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task1.Model
{
    public class ArrayCell
    {
        Cell[] cells;
        public ArrayCell(int length)
        {
            cells = new Cell[length];
            for (int i = 0; i < cells.Length; i++) cells[i] = new Cell();
        }
        public int GetLength() =>cells.Length;
        public Cell FindMin()
        {
            Cell valueMin = new Cell();
            valueMin = cells[0];
            foreach (Cell cell in cells)
            {
                if (cell.element < valueMin.element)
                {
                    valueMin = cell;
                }
            }
            return valueMin;
        }
        public Cell this[int index]
        {
            get
            {
                return cells[index];
            }
            set
            {
                cells[index] =value;
            }
        }
    }
}
