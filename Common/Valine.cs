namespace WordPress2Valine.Common
{
    public class Valine
    {
        public string comment;
        public string createdAt;
        public InsertedAt insertedAt = new InsertedAt();
        public string ip;
        public string link;
        public string mail;
        public string nick;
        public string objectId;
        public string ua;
        public string updatedAt;
        public string url;
        public string rid = null;
    }

    public class InsertedAt
    {
        public string __type = "Date";
        public string iso;
    }
}
