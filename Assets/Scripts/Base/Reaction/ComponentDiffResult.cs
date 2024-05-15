namespace Base
{
    public struct ComponentDiffResult<T> where T:struct
    {
        public enum EChangeType
        {
            Added,
            Updated,
            Removed,
            NothingChanged,
            NotPresent,
        }

        public EChangeType type;
        public T current;
        public T old;
    }
}