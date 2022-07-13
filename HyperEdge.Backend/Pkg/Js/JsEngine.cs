using System;


namespace HyperEdge.Backend.Js
{
    public static class JsEngine
    {
        private static ThreadLocal<Jint.Engine> instances = new ThreadLocal<Jint.Engine>(() => new Jint.Engine());

        public static Jint.Engine Instance
        {
            get { return instances.Value; }
        }
    }
}
