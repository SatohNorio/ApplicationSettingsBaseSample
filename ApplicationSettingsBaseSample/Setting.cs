//#define USE_USER_CONFIG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Reflection;

/* *****************************************************************************************************************
 * ＜カスタマイズされたアプリケーション構成ファイル（App.config）の作成方法＞
 * アプリケーション構成ファイルに自分で作成したクラスの値を保存したい場合、VisualStudioが自動作成するものでは
 * 対応が難しいため、下記の手順でカスタマイズしたアプリケーション構成ファイルを作成します。
 * 
 * ※ MySetting.Designer.csを編集するやり方もありますが、VisualStudioがファイルを再生成して
 *    内容が消える場合があるので、こちらの方がおすすめです。
 *
 * 1. プロジェクトの[プロパティ]→[設定]を開いて、アプリケーションスコープの設定を任意の型で何か一つ作成します。
 *    ※ App.configの雛型が作成されます。
 *
 * 2. プログラム上で初期設定したいプロパティをUserScopedSettingAttributeを付けて作成し、
 *    初期値を設定して保存するプログラムを作成し、実行します。
 *    ※ 実行後、プロパティの属性をApplicationScopedSettingAttributeに変更します。
 *
 * 3. C:\Users\[ユーザー名]\AppData\Local\[プロジェクト名]\の中にuser.configが入ったディレクトリが作成されるので、
 *    user.configをエディタで開き、userSettings要素の中身をコピーします。
 *    ※ <[プロジェクト名].MySetting>～</ [プロジェクト名].MySetting>の範囲になります。
 *
 * 4. 1.で作成したApp.configのapplicationSettings要素の中を3.でコピーした内容で上書きします。
 *
 * 5. <configSections>-<sectionGroup>-<section>要素のname属性を"[プロジェクト名].MySetting"に変更します。
 *
 * 6. プログラム上で使用し、値を取得できるか確認します。
 * ***************************************************************************************************************** */
namespace ApplicationSettingsBaseSample
{
    /// <summary>
    /// アプリケーション構成ファイルを管理します。
    /// </summary>
    public class MySetting: ApplicationSettingsBase
    {
        // ------------------------------------------------------------------------------------------------------------
        #region コンストラクタ

        /// <summary>
        /// ApplicationSettingsBaseSample.MySetting クラスの新しいインスタンスを作成します。
        /// </summary>
        public MySetting()
        {
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 読み取り専用状態を設定／取得します。
        /// </summary>
#if USE_USER_CONFIG
        public bool IsReadOnly = false;
#else
        public bool IsReadOnly = true;
#endif

        // ------------------------------------------------------------------------------------------------------------
        #region ApplicationNamesプロパティ

        /// <summary>
        /// 起動管理を行うプログラム名の一覧を取得します。
        /// </summary>
#if USE_USER_CONFIG
        [UserScopedSetting()]               // ユーザー設定を使いたい（設定を保存したい）時はこちらを使用
#else
        [ApplicationScopedSetting()]        // 読み取り専用でファイルをアプリケーションと同じパスに置きたい時はこちらを使用
#endif
        public List<ApplicationInfo> ApplicationNames
        {
            get
            {
                return (List<ApplicationInfo>)this["ApplicationNames"];
            }
            set
            {
                this["ApplicationNames"] = value;
            }
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        #region IPアドレスプロパティ

        /// <summary>
        /// IPアドレスを取得します。
        /// </summary>
#if USE_USER_CONFIG
        [UserScopedSetting()]               // ユーザー設定を使いたい（設定を保存したい）時はこちらを使用
#else
        [ApplicationScopedSetting()]        // 読み取り専用でファイルをアプリケーションと同じパスに置きたい時はこちらを使用
#endif
        public string PcIpAddress
        {
            get
            {
                return (string)this["PcIpAddress"];
            }
            set
            {
                this["PcIpAddress"] = value;
            }
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        #region UDP受信ポートプロパティ

        /// <summary>
        /// サーバから送信されるブロードキャストを受信するポート番号を取得します。
        /// </summary>
#if USE_USER_CONFIG
        [UserScopedSetting()]               // ユーザー設定を使いたい（設定を保存したい）時はこちらを使用
#else
        [ApplicationScopedSetting()]        // 読み取り専用でファイルをアプリケーションと同じパスに置きたい時はこちらを使用
#endif
        public int UdpReceivingPort
        {
            get
            {
                return (int)this["UdpReceivingPort"];
            }
            set
            {
                this["UdpReceivingPort"] = value;
            }
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------

    }
}
