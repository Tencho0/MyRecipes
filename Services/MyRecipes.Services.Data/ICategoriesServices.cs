namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesServices
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
