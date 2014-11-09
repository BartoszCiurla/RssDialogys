using NLog;

namespace RssDialogys.Domain.Concrete
{
    //bardzo zle rozwiązanie ale mam jeszcze tylko 2 godziny ...
    public static class NlogEngine
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
