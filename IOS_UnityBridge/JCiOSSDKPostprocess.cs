using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
#if UNITY_IOS || UNITY_IPHONE
using UnityEditor.iOS.Xcode;
#endif

public static class JCiOSSDKPostprocess
{
    /// <summary>
    /// System framework to be added
    /// </summary>
    static string[] systemFrameworks = new string[]
    {
        "Accelerate.framework",
        "AdSupport.framework",
        "AVFoundation.framework",
        "CoreGraphics.framework",
        "CoreLocation.framework",
        "CoreMedia.framework",
        "CoreTelephony.framework",
        "iAd.framework",
        "MessageUI.framework",
        "SafariServices.framework",
        "Security.framework",
        "SystemConfiguration.framework",
        "UIKit.framework",
        "VideoToolbox.framework",
        "WebKit.framework",
	"AppTrackingTransparency.framework"
    };



    [PostProcessBuild(999)]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {

        //#if UNITY_IOS || UNITY_IPHONE
        if (buildTarget == BuildTarget.iOS)
        {
            string pbxprojPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

            var pbxProject = new PBXProject();
            pbxProject.ReadFromFile(pbxprojPath);

            //unity 2019 version is available
            //string target = pbxProject.GetUnityMainTargetGuid();

            //unity 2018、2017 version is available
            string target = pbxProject.TargetGuidByName("Unity-iPhone");

            pbxProject.SetBuildProperty(target, "ENABLE_BITCODE", "NO");
            //pbxProject.SetBuildProperty(target, "GCC_ENABLE_OBJC_EXCEPTIONS", "YES");
            //pbxProject.SetBuildProperty(target, "GCC_C_LANGUAGE_STANDARD", "gnu99");

            //set Capability
            AddCapability(pbxProject, target, path);
            // 
            AddSystemFramework(pbxProject, target);
            
            pbxProject.AddBuildProperty(target, "OTHER_LDFLAGS", "-ObjC");
            //pbxProject.AddBuildProperty(target, "OTHER_LDFLAGS", "-fobjc-arc");

            pbxProject.AddFileToBuild(target, pbxProject.AddFile("usr/lib/libbz2.tbd", "Libraries/libbz2.tbd", PBXSourceTree.Sdk));
            pbxProject.AddFileToBuild(target, pbxProject.AddFile("usr/lib/libz.tbd", "Libraries/libz.tbd", PBXSourceTree.Sdk));
            pbxProject.AddFileToBuild(target, pbxProject.AddFile("usr/lib/libxml2.tbd", "Libraries/libxml2.tbd", PBXSourceTree.Sdk));
            pbxProject.AddFileToBuild(target, pbxProject.AddFile("usr/lib/libsqlite3.tbd", "Libraries/libsqlite3.tbd", PBXSourceTree.Sdk));
            pbxProject.AddFileToBuild(target, pbxProject.AddFile("usr/lib/libc++.tbd", "Libraries/libc++.tbd", PBXSourceTree.Sdk));
            pbxProject.AddFileToBuild(target, pbxProject.AddFile("usr/lib/libresolv.9.tbd", "Libraries/libresolv.9.tbd", PBXSourceTree.Sdk));

            pbxProject.WriteToFile(pbxprojPath);

            //Modifying "InfoPlist" Configuration
            EditInfoPlist(path);
        }
        //#endif
    }


    /// <summary>
    /// Modifying InfoPlist
    /// </summary>
    static void EditInfoPlist(string prjPath)
    {
        var plistPath = Path.Combine(prjPath, "Info.plist");
        PlistDocument plist = new PlistDocument();
        plist.ReadFromFile(plistPath);

        //Unity Two changes to be made to project routines
        plist.root.SetBoolean("ITSAppUsesNonExemptEncryption", false);
        string exitsOnSuspendKey = "UIApplicationExitsOnSuspend";
        if (plist.root.values.ContainsKey(exitsOnSuspendKey))
        {
            plist.root.values.Remove(exitsOnSuspendKey);
        }
	
	//Some channels use the Get Location feature internally
	plist.root.SetString("NSLocationWhenInUseUsageDescription", "The app needs to get your location");
        //Google id for admob
        plist.root.SetString("GADApplicationIdentifier", "ca-app-pub-9488501426181082/7319780494");
	plist.root.SetBoolean("GADIsAdManagerApp", true);

	//Get IDFA permission configuration ，iOS14 support
        plist.root.SetString("NSUserTrackingUsageDescription", "We need to access your IDFA to track the source of advertising and provide you with accurate advertising services");

        //Use "SKAdNetwork" to track conversions： iOS 14 support
        var elementArray = plist.root.CreateArray("SKAdNetworkItems");
        //google admob
        var dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "cstr6suwn9.skadnetwork");
        //Pangle
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "238da6jt44.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "22mmun2rn5.skadnetwork");
        //IronSource
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "SU67R6K2V3.skadnetwork");
        //UnityAds
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "4DZT52R2T5.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "bvpn9ufa9b.skadnetwork");
        //AdColony
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "4PFYVQ9L8R.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "YCLNXRL5PM.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "V72QYCH5UU.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "TL55SBB4FM.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "T38B2KH725.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "PRCB7NJMU6.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "PPXM28T8AP.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "MLMMFZH3R3.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "KLF5C3L5U5.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "HS6BDUKANM.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "C6K4G5QG8M.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "9T245VHMPL.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "9RD848Q2BZ.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "8S468MFL3Y.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "7UG5ZH24HU.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "4FZDC2EVR5.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "4468KM3ULZ.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "3RD42EKR43.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "2U9PT9HC89.skadnetwork");
        //Mintegral
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "KBD757YWX3.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "wg4vff78zm.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "737z793b9f.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "ydx93a7ass.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "prcb7njmu6.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "7UG5ZH24HU.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "44jx6755aq.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "2U9PT9HC89.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "W9Q455WK68.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "YCLNXRL5PM.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "TL55SBB4FM.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "8s468mfl3y.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "GLQZH8VGBY.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "c6k4g5qg8m.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "mlmmfzh3r3.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "4PFYVQ9L8R.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "av6w8kgt66.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "6xzpu9s2p8.skadnetwork");
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "hs6bdukanm.skadnetwork");
        //Sigmob
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "58922NB4GD.skadnetwork");
        //Maio
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "V4NXQHLYQP.skadnetwork");
        //Vungle
        dict = elementArray.AddDict();
        dict.SetString("SKAdNetworkIdentifier", "GTA9LK7P23.skadnetwork");
        plist.WriteToFile(plistPath);
    }


    /// <summary>
    /// set iOS Capability
    /// </summary>  
    private static void AddCapability(PBXProject pbxProject, string targetGuid, string path)
    {
        var product = pbxProject.GetBuildPropertyForAnyConfig(targetGuid, "PRODUCT_NAME");
        var rentitlementFilePath = $"Unity-iPhone/{product}.entitlements";
        var fullPath = Path.Combine(path, rentitlementFilePath);

        var doc = new PlistDocument();
        doc.root.SetBoolean("com.apple.developer.networking.wifi-info", true);
        doc.WriteToFile(fullPath);

        pbxProject.AddCapability(targetGuid, PBXCapabilityType.AccessWiFiInformation, rentitlementFilePath);
    }



    /// <summary>
    /// add system Framework
    /// </summary>
    static void AddSystemFramework(PBXProject pbxProject, string targetGuid)
    {
        foreach (var framework in systemFrameworks)
        {
            pbxProject.AddFrameworkToProject(targetGuid, framework, false);
        }
    }

}
