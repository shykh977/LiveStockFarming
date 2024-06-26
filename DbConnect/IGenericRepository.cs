namespace PwDbAssistant.DbConnect
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Search(object parameters, string query);
        IEnumerable<Model> Search<Model>(object parameters, string query);

        public List<Model> Search<Model>(object parameters, string sql, string connectionString);

        TEntity GetById(int Id);

        TEntity Delete(int Id);

        IEnumerable<Model> ExecuteQuery<Model>(object parameters, string query);
        Model CreateSP<Model>(Model model, string storedProcName);
        IEnumerable<Model> ExecuteSearch<Model>(IDictionary<string, string> objectData, string v);
    }
}
