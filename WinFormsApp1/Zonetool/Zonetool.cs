using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace HMW_Weapons_Editor.Zonetool // Replace with your actual namespace
{
    public static class Zonetool
    {
        private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "HMW_Weapons_Editor", "zonetool_config.json");

        private class Config
        {
            public string ZonetoolPath { get; set; } = "";
        }

        private static Config CurrentConfig = LoadConfig();

        public static string LinkedPath
        {
            get => CurrentConfig.ZonetoolPath;
            private set
            {
                CurrentConfig.ZonetoolPath = value;
                SaveConfig();
            }
        }

        public static bool IsLinked =>
            !string.IsNullOrWhiteSpace(LinkedPath) && File.Exists(LinkedPath);

        public static bool LinkZonetool()
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Select zonetool.exe",
                Filter = "Executable (*.exe)|*.exe",
                CheckFileExists = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LinkedPath = ofd.FileName;
                MessageBox.Show($"Zonetool linked:\n{LinkedPath}", "Zonetool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        public static void EnsureLinkedOrPrompt()
        {
            if (!IsLinked)
            {
                var result = MessageBox.Show("Zonetool is not linked. Link it now?", "Zonetool", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    LinkZonetool();
                }
            }
        }

        public static void RunZonetoolCLI(string command, string zoneName)
        {
            if (!IsLinked)
            {
                EnsureLinkedOrPrompt();
                if (!IsLinked) return;
            }

            if (string.IsNullOrWhiteSpace(zoneName))
            {
                MessageBox.Show("Zone name is required.", "Zonetool", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string arguments = $"-{command} \"{zoneName}\"";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = LinkedPath,
                    Arguments = arguments,
                    WorkingDirectory = Path.GetDirectoryName(LinkedPath),
                    UseShellExecute = true // Runs like a normal app with its own console
                };

                var process = new Process { StartInfo = psi, EnableRaisingEvents = true };

                process.Exited += (s, e) =>
                {
                    string friendlyName = command switch
                    {
                        "buildzone" => "building",
                        "dumpzone" => "dumping",
                        "loadzone" => "loading",
                        _ => "processing"
                    };

                    // Must be run on the UI thread
                    MessageBox.Show($"Zonetool finished {friendlyName} zone: {zoneName}", "Zonetool Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to run zonetool:\n{ex.Message}", "Zonetool Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void BuildZone(string zoneName) => RunZonetoolCLI("buildzone", zoneName);
        public static void DumpZone(string zoneName) => RunZonetoolCLI("dumpzone", zoneName);
        public static void LoadZone(string zoneName) => RunZonetoolCLI("loadzone", zoneName);

        private static Config LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    var json = File.ReadAllText(ConfigPath);
                    return JsonSerializer.Deserialize<Config>(json) ?? new Config();
                }
            }
            catch { }

            return new Config();
        }

        private static void SaveConfig()
        {
            try
            {
                var dir = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(ConfigPath, JsonSerializer.Serialize(CurrentConfig, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save Zonetool config:\n{ex.Message}", "Zonetool Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
