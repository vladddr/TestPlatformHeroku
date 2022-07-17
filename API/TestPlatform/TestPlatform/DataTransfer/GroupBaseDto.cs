namespace TestPlatform.API.DataTransfer
{
    public class GroupBaseDto
    {
        public GroupBaseDto(string groupName)
        {
            Name = groupName;
        }

        public GroupBaseDto()
        {

        }

        public string Name { get; set; }
    }
}
