namespace API.Messages
{
    public class CreateFolder
    {
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; } = "https://github.com";
        public bool @private { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_wiki { get; set; }

        public CreateFolder(string name, string description, bool @private)
            => (this.name, this.description, this.@private) = (name, description, @private);
    }
}