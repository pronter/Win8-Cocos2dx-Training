namespace Homework_04.Common
{
    public class OrientationStateMessage
    {
        public PageOrientations Orientation
        {
            get;
            private set;
        }

        public OrientationStateMessage(PageOrientations orientation)
        {
            Orientation = orientation;
        }
    }
}