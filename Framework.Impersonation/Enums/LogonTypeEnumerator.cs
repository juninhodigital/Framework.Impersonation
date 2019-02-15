namespace Framework.Impersonation
{
    /// <summary>
    /// Logon Type
    ///</summary>
    ///<remarks>LOGON32_LOGON_INTERACTIVE / LOGON32_LOGON_NETWORK</remarks>
    public enum LogonTypeEnumerator
    {
        /// <summary>
        /// SAM(Security Account Manager) and LSA (Local Security Authority)
        /// </summary>
        LOGON32_LOGON_INTERACTIVE = 2,

        /// <summary>
        /// Network Logon using the Active Directory
        /// </summary>
        LOGON32_LOGON_NETWORK = 3,

        /// <summary>
        /// Logon batch
        /// </summary>
        LOGON32_LOGON_BATCH = 4,

        /// <summary>
        /// Logon service
        /// </summary>
        LOGON32_LOGON_SERVICE = 5,

        /// <summary>
        /// Logon unlock
        /// </summary>
        LOGON32_LOGON_UNLOCK = 7,

        /// <summary>
        /// Clear Text
        /// </summary>
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

        /// <summary>
        /// OBSOLETE
        /// </summary>
        LOGON32_LOGON_NEW_CREDENTIALS = 9

    }
        
}
