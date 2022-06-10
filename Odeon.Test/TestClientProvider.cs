namespace Odeon.Test
{
    class TestClientProvider
    {
        private HttpClient client;
        private static object lockObject = 0;
        private static TestClientProvider mCurrent;
        public static TestClientProvider Current
        {
            get
            {
                if (mCurrent == null)
                {
                    lock (lockObject)
                    {
                        if (mCurrent == null)
                            mCurrent = new TestClientProvider();
                    }
                }
                return mCurrent;
            }
        }
        public HttpClient Client()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7070/api/");
            }
            return client;
        }

    }
}
