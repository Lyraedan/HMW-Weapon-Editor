using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using FastFiles;

public partial class FormFastFileViewer : Form
{
    private string engine = "H1";

    public FormFastFileViewer(FastFile fastFile, string engine = "H1")
    {
        this.engine = engine;
        Text = $"FastFile Viewer - {Path.GetFileName(fastFile.FilePath)}";
        BuildTree(fastFile);
    }

    private async void LoadFastFile(string path)
    {
        // Create progress label and progress bar
        var progressLabel = new Label
        {
            Text = "Initializing...",
            Dock = DockStyle.Top,
            Height = 24,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var progressBar = new ProgressBar
        {
            Style = ProgressBarStyle.Continuous,
            Dock = DockStyle.Bottom,
            Minimum = 0,
            Maximum = 100
        };

        Controls.Add(progressLabel);
        Controls.Add(progressBar);
        Controls.SetChildIndex(progressLabel, 0); // Ensure label is above
        Controls.SetChildIndex(progressBar, 1);

        // Track progress and description updates
        var progress = new Progress<(int, string)>(tuple =>
        {
            progressBar.Value = tuple.Item1;
            progressLabel.Text = tuple.Item2;
        });

        try
        {
            var fastFile = await FastFile.LoadAsync(path, engine, progress);
            BuildTree(fastFile);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load FastFile:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Controls.Remove(progressBar);
            Controls.Remove(progressLabel);
        }
    }


    private void BuildTree(FastFile fastFile)
    {
        var treeView = new TreeView { Dock = DockStyle.Fill };
        var root = new TreeNode(Path.GetFileName(fastFile.FilePath));

        AddCategoryNode(root, "Textures", fastFile.Textures);
        AddCategoryNode(root, "Materials", fastFile.Materials);
        AddCategoryNode(root, "Weapons", fastFile.Weapons);
        AddCategoryNode(root, "Models", fastFile.Models);
        AddCategoryNode(root, "Techsets", fastFile.Techsets);
        AddCategoryNode(root, "RawFiles", fastFile.RawFiles);
        AddCategoryNode(root, "StringTables", fastFile.StringTables);

        treeView.Nodes.Add(root);
        treeView.ExpandAll();
        Controls.Add(treeView);
    }

    private void AddCategoryNode(TreeNode parent, string category, List<FastFileAsset> assets)
    {
        if (assets == null || assets.Count == 0) return;

        var node = new TreeNode(category);
        foreach (var asset in assets)
            node.Nodes.Add(new TreeNode(asset.Name));
        parent.Nodes.Add(node);
    }
}
