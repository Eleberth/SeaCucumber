namespace SeaCucumber.Domain
{
    public class Map
    {
        public List<SeaCucumber> SeaCucumbers = [];

        public Map(int rows, int columns)
        {
            LastRow = rows - 1;
            LastColumn = columns - 1;
        }

        public int LastRow { get; }
        public int LastColumn { get; }

        public void AddSeaCucumber(int row, int column, Herd herd)
        {
            if (SeaCucumbers.Any(sc => sc.Row == row && sc.Column == column))
            {
                throw new ArgumentException();
            }
            SeaCucumbers.Add(new SeaCucumber(this, herd, row, column));
        }

        public void ConsiderStepEast()
        {
            Parallel.ForEach(SeaCucumbers.Where(sc => sc.Herd == Herd.EastFacing), seaCucumber =>
            {
                seaCucumber.ConsiderStep();
            });
        }

        public void ConsiderStepSouth()
        {
            Parallel.ForEach(SeaCucumbers.Where(sc => sc.Herd == Herd.SouthFacing), seaCucumber =>
            {
                seaCucumber.ConsiderStep();
            });
        }

        public int SetStep()
        {
            List<SeaCucumber> seaCucumbersCanStep = SeaCucumbers.Where(sc => sc.CanStep == true).ToList();
            int nrOfSeaCucumbersMoved = seaCucumbersCanStep.Count;

            Parallel.ForEach(seaCucumbersCanStep, seaCucumber =>
            {
                seaCucumber.SetStep();
            });

            return nrOfSeaCucumbersMoved;
        }
    }
}
