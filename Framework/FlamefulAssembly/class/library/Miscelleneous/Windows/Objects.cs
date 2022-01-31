
// Author: Dashie


using Microsoft.Win32;


namespace FlamefulAssembly
{
    namespace Systems
    {
        public enum REGISTRY_ROOTS
        {
            CLASSES_ROOT, CURRENT_USER,
            LOCAL_MACHINE, USERS, CURRENT_CONFIG,
            PERFORMANCE_DATA
        }

        public partial class EasyRegistry
        {
            public RegistryKey User = Registry.CurrentUser;
        }
    }
}