using Repository;

namespace Services.Helpers
{
    public static class ServiceHelperMethods
    {
        /// <summary>
        /// Gets the ref term id for the given type from ref term table 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        
        public static Guid GetRefTermId(string type, RepositoryContext context)
        {
            return context.RefTerm.Where(a => a.Key == type).Select(a => a.Id).SingleOrDefault();
        }

        /// <summary>
        /// Gets the ref term key for the given ref term id from the ref term table
        /// </summary>
        /// <param name="refTermId"></param>
        /// <param name="context"></param>
        /// <returns></returns>

        public static string GetRefTermKey(Guid refTermId, RepositoryContext context)
        {
            return context.RefTerm.Where(a => a.Id == refTermId).Select(a => a.Key).SingleOrDefault();
        }
    }
}


