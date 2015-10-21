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

namespace ApplicationSettingsBaseSample
{
    /// <summary>
    /// アプリケーション情報を管理するクラスを定義します。
    /// </summary>
    /// <remarks>
    /// user.configにシリアライズ化して書き込むためには下記のことに注意します。
    /// 1.引数無しのデフォルトコンストラクタを用意する。
    /// 2.プロパティにget; set;を両方publicで実装する。
    /// </remarks>
    [Serializable]
    public class ApplicationInfo
    {
        // ------------------------------------------------------------------------------------------------------------
        #region コンストラクタ

        /// <summary>
        /// SigmaStarter.ApplicationInfo クラスの新しいインスタンスを作成します。
        /// </summary>
        public ApplicationInfo()
        {

        }

        /// <summary>
        /// アプリケーション情報を使用して、SigmaStarter.ApplicationInfo クラスの新しいインスタンスを作成します。
        /// </summary>
        /// <param name="name">拡張子を含まないアプリケーション名を指定します。</param>
        /// <param name="option">アプリケーションの起動時に引数として渡す起動オプションを指定します。</param>
        public ApplicationInfo(string name, string option)
        {
            // 引数のチェック
            if (string.IsNullOrEmpty(name))
            {
                var nm = MethodBase.GetCurrentMethod().GetParameters()[0].Name;
                throw new ArgumentNullException(nm);
            }
            // オプションは指定されていなくてもよい
            if (option == null)
            {
                var nm = MethodBase.GetCurrentMethod().GetParameters()[1].Name;
                throw new ArgumentNullException(nm);
            }

            this.FName = Path.HasExtension(name) ? Path.GetFileNameWithoutExtension(name) : name;
            this.FOption = option;
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        #region アプリケーション名プロパティ

        /// <summary>
        /// 拡張子を含まないアプリケーション名を管理します。
        /// </summary>
        private string FName;

        /// <summary>
        /// SigmaStarter.ApplicationInfo クラスの新しいインスタンスを作成します。
        /// </summary>
        public string Name
        {
            get
            {
                return this.FName;
            }
            set
            {
                this.FName = value;
            }
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        #region 起動オプションプロパティ

        /// <summary>
        /// アプリケーションの起動時に引数として渡す起動オプションを管理します。
        /// </summary>
        private string FOption;

        /// <summary>
        /// SigmaStarter.ApplicationInfo クラスの新しいインスタンスを作成します。
        /// </summary>
        public string Option
        {
            get
            {
                return this.FOption;
            }
            set
            {
                this.FOption = value;
            }
        }

        #endregion
        // ------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// アプリケーション名の後ろに".exe"を付けた名前を返します。
        /// </summary>
        /// <returns>アプリケーション名の後ろに".exe"を付けた名前を返します。</returns>
        public string GetExecuteName()
        {
            return this.FName + ".exe";
        }

        /// <summary>
        /// オブジェクトの内容を文字列に変換して、結果を返します。
        /// </summary>
        /// <returns>アプリケーション名とオプションを結合した文字列を返します。</returns>
        public override string ToString()
        {
            return this.GetExecuteName() + " " + this.FOption;
        }
    }
}
