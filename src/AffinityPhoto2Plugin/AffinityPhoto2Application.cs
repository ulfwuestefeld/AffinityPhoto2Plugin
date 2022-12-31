namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using System.Management.Automation;

    // This class can be used to connect the Loupedeck plugin to an application.

    public class AffinityPhoto2Application : ClientApplication
    {
        public AffinityPhoto2Application()
        {
        }

        // This method can be used to link the plugin to a Windows application.
        protected override String GetProcessName() => "Photo.exe";

        // This method can be used to link the plugin to a macOS application.
        protected override String GetBundleName() => "";

        // This method can be used to check whether the application is installed or not.
        public override ClientApplicationStatus GetApplicationStatus()
        {
            // Get-AppxPackage -Name "*AffinityPhoto*"
            /*PowerShell ps = PowerShell.Create();
            ps.AddCommand("Get-AppxPackage -Name \"*AffinityPhoto*\"");
            ps.Invoke();*/
            return ClientApplicationStatus.Unknown;
        }
    }
}
