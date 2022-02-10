using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMPairs.Services
{
    class GameBusinessLogic
    {
        int pieceOrSpace = 0;
        int blackOrRed = 0;
        public ObservableCollection<ObservableCollection<Cell>> cells;
        public GameBusinessLogic(ObservableCollection<ObservableCollection<Cell>> cells)
        {
            this.cells = cells;
        }

        private bool TurnCard(Cell cell)
        {
            if(cell.Image== "/MVVMPairs;component/Resources/redpiece.jpg")
            {
                cells.ElementAt(cell.X).ElementAt(cell.Y).Image = "/MVVMPairs;component/Resources/redclicked.jpg";
                cell.Image = "/MVVMPairs;component/Resources/redclicked.jpg";
                return true;
            }
            else
            {
                if(cell.Image== "/MVVMPairs;component/Resources/blackpiece.jpg")
                {
                    cells.ElementAt(cell.X).ElementAt(cell.Y).Image = "/MVVMPairs;component/Resources/blackclicked.jpg";
                    cell.Image = "/MVVMPairs;component/Resources/blackclicked.jpg";
                    return true;
                }
                else
                {
                    if(cell.Image == "/MVVMPairs;component/Resources/redking.jpg")
                    {
                        cells.ElementAt(cell.X).ElementAt(cell.Y).Image = "/MVVMPairs;component/Resources/redclickedking.jpg";
                        cell.Image = "/MVVMPairs;component/Resources/redclickedking.jpg";
                        return true;
                    }
                    else
                    {
                        if(cell.Image == "/MVVMPairs;component/Resources/blackking.jpg")
                        {
                            cells.ElementAt(cell.X).ElementAt(cell.Y).Image = "/MVVMPairs;component/Resources/blackclickedking.jpg";
                            cell.Image = "/MVVMPairs;component/Resources/blackclickedking.jpg";
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool SimpleJump(Cell currentCell, Cell previousCell)
        {
            bool found = false;

            if (previousCell.Image == "/MVVMPairs;component/Resources/blackclicked.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg"
                || previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
            {
                if (currentCell.Image == "/MVVMPairs;component/Resources/blackempty.jpg")
                {
                    if (previousCell.Y + 2 < 8)
                    {
                        if (currentCell.Y == previousCell.Y + 2)
                        {
                            if (previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                            {
                                if(currentCell.X - 1>=0)
                                {
                                    if (cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                    || cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redking.jpg")
                                    {
                                        found = true;

                                        currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";

                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y + 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                    }
                                }
                            }
                            if (previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
                            {
                                if(currentCell.X + 1<8)
                                {
                                    if (cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/blackpiece.jpg"
                                    || cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/blackking.jpg")
                                    {
                                        found = true;

                                        currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";

                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y + 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                    }
                                }
                            }
                            if (previousCell.Image == "/MVVMPairs;component/Resources/blackclicked.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                            {
                                if(currentCell.X + 1<8)
                                {
                                    if (cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                    || cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redking.jpg")
                                    {
                                        found = true;
                                        if (previousCell.Image == "/MVVMPairs;component/Resources/blackclicked.jpg")
                                        {
                                            if (currentCell.X == 0)
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                            }
                                            else
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                                            }
                                        }
                                        else
                                        {
                                            currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                            cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                        }

                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y + 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                    }
                                }
                            }
                            if(previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
                            {
                                if(currentCell.X - 1>=0)
                                {
                                    if (cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/blackpiece.jpg"
                                    || cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/blackking.jpg")
                                    {
                                        found = true;
                                        if (previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg")
                                        {
                                            if (currentCell.X == 7)
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";
                                            }
                                            else
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                                            }
                                        }
                                        else
                                        {
                                            currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                                            cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";
                                        }
                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y + 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                    }
                                }
                            }
                        }
                    }
                    if (previousCell.Y - 2 >= 0)
                    {
                        if (currentCell.Y == previousCell.Y - 2)
                        {
                            if (previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                            {
                                if(currentCell.X - 1>=0)
                                {
                                    if (cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                    || cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redking.jpg")
                                    {
                                        found = true;

                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y - 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                    }
                                }
                            }
                            if (previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
                            {
                                if(currentCell.X + 1<8)
                                {
                                    if (cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/blackpiece.jpg"
                                    || cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y = 1).Image == "/MVVMPairs;component/Resources/blackking.jpg")
                                    {
                                        found = true;

                                        currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";

                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";


                                        cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y - 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                    }
                                }
                            }
                            if (previousCell.Image == "/MVVMPairs;component/Resources/blackclicked.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                            {
                                if(currentCell.X + 1<8)
                                {
                                    if (cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                    || cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redking.jpg")
                                    {
                                        found = true;
                                        if (previousCell.Image == "/MVVMPairs;component/Resources/blackclicked.jpg")
                                        {
                                            if (currentCell.X == 0)
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                            }
                                            else
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                                            }
                                        }
                                        else
                                        {
                                            currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                            cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                                        }
                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X + 1).ElementAt(previousCell.Y - 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                    }
                                }
                            }
                            
                            if(previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
                            {
                                if(currentCell.X - 1>=0)
                                {
                                    if (cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/blackpiece.jpg"
                                    || cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/blackking.jpg")
                                    {
                                        found = true;
                                        if (previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg")
                                        {
                                            if (currentCell.X == 7)
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";

                                            }
                                            else
                                            {
                                                currentCell.Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                                                cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redpiece.jpg";

                                            }
                                        }
                                        else
                                        {
                                            currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                                            cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";
                                        }
                                        previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                                        cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                                        cells.ElementAt(currentCell.X - 1).ElementAt(previousCell.Y - 1).Image = "/MVVMPairs;component/Resources/blackempty.jpg";


                                    }
                                }
                            }
                        }
                    }

                }
            }
            
            return found;
        }
        private bool PlaceCard(Cell currentCell, Cell previousCell)
        {
            bool done = false;
            if(previousCell.Image== "/MVVMPairs;component/Resources/blackclicked.jpg")
            {
                if(previousCell.X - 1==currentCell.X && (previousCell.Y==currentCell.Y-1 || previousCell.Y == currentCell.Y + 1))
                {
                    if(currentCell.X==0)
                    {
                        currentCell.Image= "/MVVMPairs;component/Resources/blackking.jpg";
                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                    }
                    else
                    {
                        currentCell.Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                    }
                    previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                    done = true;
                }
            }
            if(previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg")
            {
                if (previousCell.X + 1 == currentCell.X && (previousCell.Y == currentCell.Y - 1 || previousCell.Y == currentCell.Y + 1))
                {
                    if (currentCell.X == 7)
                    {
                        currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";
                    }
                    else
                    {
                        currentCell.Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                    }
                    
                    previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                    done = true;
                }
            }
            if(previousCell.Image== "/MVVMPairs;component/Resources/blackclickedking.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
            {
                if((currentCell.X==previousCell.X-1 && (currentCell.Y==previousCell.Y-1||
                    currentCell.Y==previousCell.Y+1))
                    ||(currentCell.X==previousCell.X+1 && (currentCell.Y == previousCell.Y - 1 ||
                    currentCell.Y == previousCell.Y + 1)))
                {
                    if(previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                    {
                        currentCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                    }
                    else
                    {
                        currentCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                        cells.ElementAt(currentCell.X).ElementAt(currentCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";
                    }
                    previousCell.Image = "/MVVMPairs;component/Resources/blackempty.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackempty.jpg";

                    done = true;
                }
            }
            if(done==false)
            {
                if(previousCell.Image == "/MVVMPairs;component/Resources/blackclicked.jpg")
                {
                    previousCell.Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackpiece.jpg";
                }
                if(previousCell.Image == "/MVVMPairs;component/Resources/redclicked.jpg")
                {
                    previousCell.Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/redpiece.jpg";
                }
                if (previousCell.Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                {
                    previousCell.Image = "/MVVMPairs;component/Resources/blackking.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/blackking.jpg";
                }
                if (previousCell.Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
                {
                    previousCell.Image = "/MVVMPairs;component/Resources/redking.jpg";
                    cells.ElementAt(previousCell.X).ElementAt(previousCell.Y).Image = "/MVVMPairs;component/Resources/redking.jpg";
                }
            }
            return done;
        }

        private bool MultipleJump(Cell currentCell, Cell previousCell)
        {
            bool next = true;
            bool moved = false;

            while(next==true)
            {
                if(SimpleJump(currentCell, previousCell)==true)
                {
                    moved = true;
                    previousCell = currentCell;
                    if(previousCell.Image== "/MVVMPairs;component/Resources/redpiece.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/redking.jpg")
                    {
                        if (previousCell.X + 2 < 8 && previousCell.Y + 2 < 8)
                        {
                            if (cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y + 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/blackpiece.jpg" 
                                || cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/blackking.jpg"))
                            {
                                currentCell = cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y + 2);
                                if(previousCell.Image == "/MVVMPairs;component/Resources/redpiece.jpg")
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/redclicked.jpg";
                                }
                                else
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/redclickedking.jpg";
                                }
                                
                            }
                        }
                        if (previousCell.X + 2 < 8 && previousCell.Y - 2 >= 0)
                        {
                            if (cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y - 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/blackpiece.jpg"
                                || cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/blackking.jpg"))
                            {
                                currentCell = cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y - 2);
                                if (previousCell.Image == "/MVVMPairs;component/Resources/redpiece.jpg")
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/redclicked.jpg";
                                }
                                else
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/redclickedking.jpg";
                                }
                            }
                        }
                        
                    }
                    if(previousCell.Image == "/MVVMPairs;component/Resources/blackking.jpg")
                    {
                        if (previousCell.X + 2 < 8 && previousCell.Y + 2 < 8)
                        {
                            if (cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y + 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                || cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redking.jpg"))
                            {
                                currentCell = cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y + 2);
                                previousCell.Image = "/MVVMPairs;component/Resources/blackclickedking.jpg";
                            }
                        }
                        if (previousCell.X + 2 < 8 && previousCell.Y - 2 >= 0)
                        {
                            if (cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y - 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                || cells.ElementAt(previousCell.X + 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redking.jpg"))
                            {
                                currentCell = cells.ElementAt(previousCell.X + 2).ElementAt(previousCell.Y - 2);
                                previousCell.Image = "/MVVMPairs;component/Resources/blackclickedking.jpg";
                            }
                        }
                    }
                    if (previousCell.Image == "/MVVMPairs;component/Resources/blackpiece.jpg" || previousCell.Image == "/MVVMPairs;component/Resources/blackking.jpg")
                    {
                        if (previousCell.X - 2 >= 0 && previousCell.Y + 2 < 8)
                        {
                            if (cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y + 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                || cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redking.jpg"))
                            {
                                currentCell = cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y + 2);
                                if(previousCell.Image == "/MVVMPairs;component/Resources/blackpiece.jpg")
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/blackclicked.jpg";
                                }
                                else
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/blackclickedking.jpg";
                                }
                                
                            }
                        }
                        if (previousCell.X - 2 >= 0 && previousCell.Y - 2 >= 0)
                        {
                            if (cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y - 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                || cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redking.jpg"))
                            {
                                currentCell = cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y - 2);
                                if (previousCell.Image == "/MVVMPairs;component/Resources/blackpiece.jpg")
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/blackclicked.jpg";
                                }
                                else
                                {
                                    previousCell.Image = "/MVVMPairs;component/Resources/blackclickedking.jpg";
                                }
                            }
                        }
                        if (previousCell.Image == "/MVVMPairs;component/Resources/redking.jpg")
                        {
                            if (previousCell.X - 2 >= 0 && previousCell.Y + 2 < 8)
                            {
                                if (cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y + 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                || cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y + 1).Image == "/MVVMPairs;component/Resources/redking.jpg"))
                                {
                                    currentCell = cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y + 2);
                                    previousCell.Image = "/MVVMPairs;component/Resources/redclickedking.jpg";
                                }
                            }
                            if(previousCell.X - 2 >= 0 && previousCell.Y - 2 >= 0)
                            {
                                if (cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y - 2).Image == "/MVVMPairs;component/Resources/blackempty.jpg" &&
                                (cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redpiece.jpg"
                                || cells.ElementAt(previousCell.X - 1).ElementAt(previousCell.Y - 1).Image == "/MVVMPairs;component/Resources/redking.jpg"))
                                {
                                    currentCell = cells.ElementAt(previousCell.X - 2).ElementAt(previousCell.Y - 2);
                                    previousCell.Image = "/MVVMPairs;component/Resources/redclickedking.jpg";
                                }
                            }
                        }
                    }
                }
                else
                {
                    next = false;
                }
            }


            return moved;
        }

        private string CheckWinning()
        {
            int reds = 0;
            int blacks = 0;
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    if(cells[i][j].Image== "/MVVMPairs;component/Resources/redpiece.jpg" || cells[i][j].Image == "/MVVMPairs;component/Resources/redclicked.jpg"
                        || cells[i][j].Image == "/MVVMPairs;component/Resources/redking.jpg" || cells[i][j].Image == "/MVVMPairs;component/Resources/redclickedking.jpg")
                    {
                        reds++;
                    }
                    if(cells[i][j].Image == "/MVVMPairs;component/Resources/blackpiece.jpg" || cells[i][j].Image == "/MVVMPairs;component/Resources/blackclicked.jpg"
                        || cells[i][j].Image == "/MVVMPairs;component/Resources/blackking.jpg" || cells[i][j].Image == "/MVVMPairs;component/Resources/blackclickedking.jpg")
                    {
                        blacks++;
                    }
                }
            }
            if(reds==0)
            {
                return "black";
            }
            if(blacks==0)
            {
                return "red";
            }
            return "none";
        }

        public bool Move(Cell currentCell)
        {
            bool piecePlaced = false;
            Helper.CurrentCell = currentCell;
            if (Helper.PreviousCell==null)
            {
                if(TurnCard(currentCell)==true)
                {
                    Helper.PreviousCell = currentCell;
                }
            }
            else
            {
                if(MultipleJump(currentCell,Helper.PreviousCell)==false)
                {
                    if (PlaceCard(currentCell, Helper.PreviousCell))
                    { piecePlaced = true; }
                }
                else
                {
                    Helper.PreviousCell = null;
                }
                if(piecePlaced==false && Helper.PreviousCell==null)
                {
                    piecePlaced = true;
                }
                Helper.PreviousCell = null;
            }

            if(CheckWinning()=="red")
            {
                _ = MessageBox.Show("Red player won!");
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else
            {
                if(CheckWinning()=="black")
                {
                    _ = MessageBox.Show("Black player won!");
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            return piecePlaced;

        }

        public void ClickAction(Cell obj)
        {
            if(pieceOrSpace%2==0)
            {
                if (blackOrRed % 2 == 0 && (obj.Image == "/MVVMPairs;component/Resources/redpiece.jpg" || obj.Image== "/MVVMPairs;component/Resources/redking.jpg"))
                {
                    blackOrRed++;
                    pieceOrSpace++;
                    Move(obj);
                }
                if (blackOrRed % 2 != 0 && (obj.Image == "/MVVMPairs;component/Resources/blackpiece.jpg" || obj.Image == "/MVVMPairs;component/Resources/blackking.jpg"))
                {
                    blackOrRed++;
                    pieceOrSpace++;
                    Move(obj);
                }
            }
            else
            {
                if(obj.Image== "/MVVMPairs;component/Resources/blackempty.jpg" || obj.Image == "/MVVMPairs;component/Resources/redempty.jpg")
                {
                    
                    if(Move(obj))
                    {
                        pieceOrSpace++;
                    }
                    else
                    {
                        pieceOrSpace--;
                        blackOrRed--;
                    }
                }
            }
            
        }
    }
}
