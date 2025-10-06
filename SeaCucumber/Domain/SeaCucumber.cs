namespace SeaCucumber.Domain
{
    public enum Herd
    {
        EastFacing,
        SouthFacing
    }

    public class SeaCucumber
    {
        public SeaCucumber(Map map, Herd herd, int row, int column)
        {
            Map = map;
            Herd = herd;
            Row = row;
            Column = column;
        }

        public Map Map { get; }
        public Herd Herd { get; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public bool CanStep { get; private set; }

        public void ConsiderStep()
        {
            switch (Herd)
            {
                case Herd.EastFacing:
                    CanStep = !Map.SeaCucumbers.Where(s => s.Row == Row).Any(s => s.Column == NextColumn());
                    break;

                default:
                    CanStep = !Map.SeaCucumbers.Where(s => s.Column == Column).Any(s => s.Row == NextRow());
                    break;
            }
        }

        public void SetStep()
        {
            if (CanStep)
            {
                switch (Herd)
                {
                    case Herd.EastFacing:
                        Column = NextColumn();
                        break;
                    default:
                        Row = NextRow();
                        break;
                }
                                
                CanStep = false;
            }
        }

        private int NextRow()
        {
            return Row == Map.LastRow ? 0 : Row + 1;
        }

        private int NextColumn()
        {
            return Column == Map.LastColumn ? 0 : Column + 1;
        }
    }
}
