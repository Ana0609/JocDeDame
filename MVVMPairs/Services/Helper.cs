using MVVMPairs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class Helper
    {
        public static Cell CurrentCell { get; set; }
        public static Cell PreviousCell { get; set; }

        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard()
        {
            ObservableCollection<ObservableCollection<Cell>> final = new ObservableCollection<ObservableCollection<Cell>>();

            for (int i = 0; i < 8; i++)
            {
                ObservableCollection<Cell> obsCol = new ObservableCollection<Cell>();
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/redempty.jpg"));
                        else
                        {
                            if(i==0 || i==2) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/redpiece.jpg"));
                            if (i == 4) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/blackempty.jpg"));
                            if (i == 6) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/blackpiece.jpg"));
                        }
                    }
                    else
                    {
                        if(j%2!=0) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/redempty.jpg"));
                        else
                        {
                            if (i == 5 || i == 7) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/blackpiece.jpg"));
                            if (i == 1) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/redpiece.jpg"));
                            if (i == 3) obsCol.Add(new Cell(i, j, "/MVVMPairs;component/Resources/blackempty.jpg"));
                        }

                    }
                }
                final.Add(obsCol);

            }

            return final;
        }
    }
}
