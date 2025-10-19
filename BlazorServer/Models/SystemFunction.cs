namespace BlazorServer.Models
{
    public class SystemFunction
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = "bi-app";
        public List<Rol> AllowedRoles { get; set; } = new();

        public SystemFunction() { }

        public SystemFunction(string title, string description, string url, string icon, params Rol[] roles)
        {
            Title = title;
            Description = description;
            Url = url;
            Icon = icon;
            AllowedRoles = roles.ToList();
        }
    }
}
