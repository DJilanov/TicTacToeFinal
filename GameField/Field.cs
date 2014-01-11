using System;

namespace TicTacToe.GameField
{
    public class Field : ICloneable
    {
        private Block[,] BlocksArray;

        private int size = 3;

        public Field(Block[,] array) :this()
        {
           for(int i=0;i<3;i++)
               for(int j=0;j<3;j++)
                   BlocksArray[i,j] = array[i,j];
        }

        public Field()
        {
            BlocksArray = new Block[3, 3];
        }

        //Added possibility for 4x4 field with 3 players
        public Field(int size)
        {
            if (size == 4)
            {
                this.BlocksArray = new Block[4,4];
                this.size = 4;
            }
            else
            {
                this.BlocksArray = new Block[3, 3];
            }
        }

        //Getting the size of the field
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        //indexer get/set
        public Block this[int row, int col]
        {
            get 
            { 
                return BlocksArray[row, col]; 
            }
            set { BlocksArray[row, col] = value; }
        }

        //Can be Cloned
        public Field CopyField()
        {
            Field result = new Field(this.size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = this[i, j];
                }
            }

            return result;
        }

        public object Clone()
        {
            Field result = new Field(this.size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = this[i, j];
                }
            }

            return result;
        }
    }
}