namespace FamilyTreeGenerator.TreeGeneratorFiles
{
    public class ParseTableSettings
    {
        private int offset;
        public int Offset
        {
            set
            {
                if (value > 0) offset = value;
                else offset = 0;
            }
            get
            {
                return offset;
            }
        }
        private int rowOffset;
        public int RowOffset
        {
            set
            {
                if (value > 0) rowOffset = value;
                else rowOffset = 1;
            }
            get
            {
                return rowOffset;
            }
        }
        private int endOffset;
        public int EndOffset
        {
            set
            {
                if (value > 0) endOffset = value;
                else endOffset = 1;
            }
            get
            {
                return endOffset;
            }
        }
        public ParseTableSettings(int offset, int rowOffset)
        {
            this.Offset = offset;
            this.RowOffset = rowOffset;
            this.EndOffset = rowOffset - 1;
        }
    }
}