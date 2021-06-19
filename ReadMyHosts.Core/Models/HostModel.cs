using PostSharp.Patterns.Contracts;

namespace ReadMyHosts.Core.Models

{
    public class Host
    {
        [Required]
        public byte[] FullIp { get; set; } = new byte[4];

        [Required]
        public int HostId { get; set; }

        [Required]
        public string HostName { get; set; }

        public bool IsEnabled { get; set;}
    }
}