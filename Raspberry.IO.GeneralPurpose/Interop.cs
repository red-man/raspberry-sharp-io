using System.Runtime.InteropServices;

namespace Raspberry.IO.GeneralPurpose
{
    internal static class Interop
    {
        private static readonly object lockObject = new object();
        private static int referenceCount;

        public static void Reference()
        {
            lock (lockObject)
            {
                if (referenceCount++ == 0)
                    bcm2835_init();
            }
        }

        public static void Release()
        {
            lock (lockObject)
            {
                if (--referenceCount == 0)
                    bcm2835_close();
            }
        }

        #region Interop Methods

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_init")]
        private static extern int bcm2835_init();

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_close")]
        private static extern int bcm2835_close();

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_gpioperi_read")]
        public static extern uint bcm2835_gpioperi_read(uint group);

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_gpio_fsel")]
        public static extern void bcm2835_gpio_fsel(uint pin, uint mode);

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_gpio_write")]
        public static extern void bcm2835_gpio_write(uint pin, uint value);

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_gpio_lev")]
        public static extern uint bcm2835_gpio_lev(uint pin);

        [DllImport("libbcm2835.so", EntryPoint = "bcm2835_gpio_set_pud")]
        public static extern void bcm2835_gpio_set_pud(uint pin, uint pud);

        #endregion
    }
}