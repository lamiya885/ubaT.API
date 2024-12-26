namespace ubaT.Extension
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Random<T> (this IQueryable<T> query,int randNumber)
        {
            Random random=new Random ();
           int num = random.Next (0,randNumber);
            return query.Skip(num);
        }
    }
}
