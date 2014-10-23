using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBitcoin.Tools
{
    public class Options
    {
        [Option("k", DefaultValue = false, Required = false, HelpText = "Generate a new key")]
        public bool GenerateKey
        {
            get;
            set;
        }

        [Option("ek", DefaultValue = false, Required = false, HelpText = "Generate an encrypted key (BIP38)")]
        public bool GenerateEncryptedKey
        {
            get;
            set;
        }

        [Option("dek", DefaultValue = false, Required = false, HelpText = "Decrypt encrypted key (BIP38)")]
        public bool DecryptEncryptedKey
        {
            get;
            set;
        }


        [Option("n", DefaultValue = "mainnet", Required = false, HelpText = "Network : mainnet or testnet (default : mainnet)")]
        public string Network
        {
            get;
            set;
        }

        string _Usage;
        [HelpOption('?', "help", HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            if (_Usage == null)
            {
                _Usage = HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
                _Usage = _Usage.Replace("NBitcoin 1.0.0.0", "NBitcoin.Tools " + typeof(Program).Assembly.GetName().Version);
            }
            return _Usage;
            //
        }
    }
}
