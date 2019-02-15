using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Framework.Impersonation
{
    /// <summary>
    /// Impersonates the user represented by the WindowsIdentity object
    /// </summary>
    /// <example>
    ///     <code>
    ///     using System;
    ///     using System.Security;
    ///     using System.Security.Principal;
    ///     using Framework.Impersonation;
    ///     
    ///     public class ImpersonateSample
    ///     {
    ///         static void Main(string[] args)
    ///         {
    ///            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
    ///
    ///            IntPtr Token = IntPtr.Zero;
    ///
    ///            Impersonation.LogonUser
    ///            (
    ///                "UserName",
    ///                ".", // "." = Autentica um Built-in User Account na máquina local | "Domain" = Autentica usando o Active Directory em um Dominio.
    ///                "Password",
    ///                NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE,
    ///                NativeMethods.ProviderType.LOGON32_PROVIDER_DEFAULT,
    ///                out Token
    ///            );
    ///
    ///            if (Token == IntPtr.Zero) return;
    ///
    ///            WindowsIdentity WI = new WindowsIdentity(Token);
    ///
    ///            Impersonation.CloseHandle(Token);
    ///
    ///            try
    ///            {
    ///                using (WindowsImpersonationContext WIC = WI.Impersonate())
    ///                {
    ///                    Console.WriteLine(WindowsIdentity.GetCurrent().Name);
    ///                }
    ///            }
    ///            catch (Exception)
    ///            {
    ///                throw;
    ///            }
    ///            finally
    ///            {
    ///                Console.WriteLine(WindowsIdentity.GetCurrent().Name);
    ///            }
    ///         }
    ///     }
    ///     </code>
    /// </example>
    public static partial class Impersonation
    {
        #region| Methods |

        /// <summary>
        /// Impersonates the user represented by the WindowsIdentity object
        /// </summary>
        /// <param name="Username">Username</param>
        /// <param name="Domain">Domain</param>
        /// <param name="Password">Password</param>
        /// <param name="LogonType">LogonType</param>
        /// <param name="ProviderType">ProviderType</param>
        /// <param name="Token">Token</param>
        /// <returns>IntPtr that handles the memory pointer</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport("advapi32.dll")]
        public static extern int LogonUser
        (
            string Username,
            string Domain,
            string Password,
            LogonTypeEnumerator LogonType,
            ProviderTypeEnumerator ProviderType,
            out IntPtr Token
        );

        /// <summary>
        /// Undo method to end the impersonation.
        /// </summary>
        /// <param name="phToken">IntPtr</param>
        /// <returns>bool</returns>
        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr phToken); 
        
        #endregion

    }
}
