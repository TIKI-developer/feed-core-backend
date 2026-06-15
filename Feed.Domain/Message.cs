namespace Feed.Domain
{
    public class Message
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public string Source { get; private set; }

        private Message() { }
    }
}
