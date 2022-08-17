namespace ReDoPeAPI.GraphQL.Mutations.MutationReturnTypes
{
    public class MutationReturnType
    {
        public int Code { get; set; }
        public string Label { get; set; }
        public string Domain { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
