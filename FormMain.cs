using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace JiaowuHelper
{
	public partial class FormMain : Form
	{
		Login login;
		Score score;
		Elective elective;
		FormHelper helper = null;
		bool scoreIsLoad = false;
		volatile bool scoreLoading = false;
		bool electiveIsLoad = false;
		volatile bool electiveLoading = false;
		bool curriculumIsLoad = false;
		volatile bool curriculumLoading = false;
		bool testInfoIsLoad = false;
		volatile bool testInfoLoading = false;
		bool testLevelIsLoad = false;
		volatile bool testLevelLoading = false;
		bool firstRun = true;
		private delegate void ChangeControlShow(Control control, bool show);
		private ChangeControlShow controlChange;
		private delegate void AddControl(Control parent, Control child);
		private AddControl addControl;
		private delegate void SetWebBowserDocText(WebBrowser wb, string text);
		private SetWebBowserDocText setWbDT;
		public FormMain()
		{
			controlChange = new ChangeControlShow(changeControlShow);
			addControl = new AddControl(addControlAction);
			setWbDT = new SetWebBowserDocText(setWbDocumentText);
			this.login = Login.get();
			InitializeComponent();
			score = new Score();
			elective = new Elective();
		}
		private void setWbDocumentText(WebBrowser wb, string str) {
			if (wb.InvokeRequired)
			{
				wb.Invoke(setWbDT, wb, str);
			}
			else {
				wb.DocumentText = str;
			}
		}
		private void addControlAction(Control parent, Control child)
		{
			if (parent.InvokeRequired)
			{
				parent.Invoke(addControl, parent, child);
			}
			else
			{
				parent.Controls.Add(child);
			}
		}
		private void changeControlShow(Control control, bool show)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(controlChange, control, show);
			}
			else
			{
				if (show) control.Show();
				else control.Hide();
			}
		}
		private void FormMain_Load(object sender, EventArgs e)
		{
			this.Icon = Resource.jiaowu;
			Location = Postion.getPostion(this, 0.4f, 0.4f, null);
			Activate();
			this.Text = "欢迎 " + Login.get().name + " 登录 " + this.Text;
		}

		private void getInfo()
		{
			Dictionary<string, string> list = Info.getUserInfoList();
			label_candidates.Text = list["candidates"];
			label_grade.Text = list["grade"];
			label_idcard.Text = list["idcard"];
			label_className.Text = list["className"];
			label_level.Text = list["level"];
			label_political.Text = list["political"];
			label_direction.Text = list["direction"];
			label_sex.Text = list["sex"];
			label_year.Text = list["year"];
			label_ethnic.Text = list["ethnic"];
			label_discipline.Text = list["discipline"];
			label_id.Text = list["id"];
			label_faculty.Text = list["faculty"];
			label_name.Text = list["name"];

			pictureBox_photo.Image = Url.GetImageWithCookie(login.homeUrl + "readimagexs.aspx?xh=" + login.id);

			login.info = list;
		}

		private void tabPage_sorce_Enter(object sender, EventArgs e)
		{
			if (scoreIsLoad) return;
			loadSorcePage();
		}

		private void loadSorcePage()
		{
			tabControl_scoreList.Controls.Clear();
			Thread therad = new Thread(new ThreadStart(SocreProcessThread));
			therad.Start();
			changeControlShow(label_scoreLading, true);
		}

		private void SocreProcessThread()
		{
			if (scoreLoading == true) return;
			scoreLoading = true;
			while (true)
			{
				TabPage[] tabPages = score.getAll();
				if (tabPages == null)
				{
					if (MessageBox.Show("成绩加载失败，此处数据容易出现异常，请尝试重试", "成绩加载失败",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
						continue;
				}
				else
				{
					for (int i = tabPages.Length - 1; i >= 0; i--)
					{
						addControlAction(tabControl_scoreList, tabPages[i]);
					}
					scoreIsLoad = true;
				}
				break;
			}
			scoreLoading = false;
			changeControlShow(label_scoreLading, false);
		}

		private void buttonScoreRef_Click(object sender, EventArgs e)
		{
			scoreIsLoad = false;
			loadSorcePage();
		}

		private void button_infoRefresh_Click(object sender, EventArgs e)
		{
			getInfo();
		}

		private void ToolStripMenuItem_JiaowuSite_Click(object sender, EventArgs e)
		{
			Browser.openUrl(login.homeUrl);
		}

		private void ToolStripMenuItem_author_Click(object sender, EventArgs e)
		{
			Browser.openAuthorPage();
		}

		private void ToolStripMenuItem_Screenshot_Click(object sender, EventArgs e)
		{
			Image image = new Bitmap(Width, Height);
			Graphics g = Graphics.FromImage(image);
			g.CopyFromScreen(Location, new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
			Clipboard.SetImage(image);
			MessageBox.Show("成功截图到剪切板");
		}

		private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ToolStripMenuItem_Logout_Click(object sender, EventArgs e)
		{
			Logout();
		}

		private void ToolStripMenuItem_helper_Click(object sender, EventArgs e)
		{
			new AboutBox().ShowDialog();
		}
		private void Logout()
		{
			login.Logout();
			Close();
		}

		private void toolStripMenuItem_help_Click(object sender, EventArgs e)
		{
			if (helper == null || helper.IsDisposed)
			{
				helper = new FormHelper();
				helper.Show();
				helper.Location = Postion.getPostion(helper, 0.5f, 0.5f, this);
			}
			else
			{
				helper.Activate();
			}
		}

		private void button_electiveRefresh_Click(object sender, EventArgs e)
		{
			loadElectivePage();
		}

		private void tabPage_Elective_Enter(object sender, EventArgs e)
		{
			if (electiveIsLoad) return;
			loadElectivePage();
		}
		private void loadElectivePage()
		{
			panel_Curriculum.Controls.Clear();
			panel_Selected.Controls.Clear();
			Thread therad = new Thread(new ThreadStart(ElectiveProcessThread));
			therad.Start();
			changeControlShow(label_electiveLoading, true);
		}

		private void ElectiveProcessThread()
		{
			if (electiveLoading == true) return;
			electiveLoading = true;
			while (true)
			{
				if (elective.getStatus() == false)
				{
					if (elective.isClosed())
					{
						MessageBox.Show("选课系统被关闭,请等待！", "系统关闭", MessageBoxButtons.OK, MessageBoxIcon.Information);
						electiveIsLoad = true;
						break;
					}
					if (MessageBox.Show("选课数据加载失败，请尝试重试", "选课数据加载失败",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
						continue;
				}
				else
				{
					addControlAction(panel_Selected, elective.getSelectView());
					addControlAction(panel_Curriculum, elective.getCurriculum());
					electiveIsLoad = true;
				}
				break;
			}
			electiveLoading = false;
			changeControlShow(label_electiveLoading, false);
		}

		private void FormMain_Activated(object sender, EventArgs e)
		{
			//由于自动登录会导致次窗口未激活
			if (firstRun == false) return;
			firstRun = true;
			getInfo();
		}

		private void button_curriculmRefresh_Click(object sender, EventArgs e)
		{
			loadCurriculum();
		}

		private void tabPage_Curriculm_Enter(object sender, EventArgs e)
		{
			if (curriculumIsLoad) return;
			loadCurriculum();
		}
		private void loadCurriculum()
		{
			webBrowser_curriculm.DocumentText = "";
			Thread thread = new Thread(new ThreadStart(CurriculumProcessThread));
			thread.Start();
			changeControlShow(label_curriculumLoading, true);
		}
		private void CurriculumProcessThread()
		{
			if (curriculumLoading) return;
			curriculumLoading = true;
			string table;
			while (true)
			{
				table = Info.getCurriculumHtmlTable();
				if (table == "")
				{
					if (MessageBox.Show("课程表加载失败，请尝试重试", "加载失败",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
						continue;
				}
				else
				{
					setWbDocumentText(webBrowser_curriculm,table);
					curriculumIsLoad = true;
				}
				break;
			}
			curriculumLoading = false;
			changeControlShow(label_curriculumLoading, false);
		}

		private void tabPage_TestInfo_Enter(object sender, EventArgs e)
		{
			if (testInfoIsLoad) return;
			TestInfoLoad();
		}

		private void button_testInfoRefresh_Click(object sender, EventArgs e)
		{
			TestInfoLoad();
		}
		private void TestInfoLoad() {
			panel_testInfo.Controls.Clear();
			Thread thread = new Thread(new ThreadStart(TestInfoProcessThread));
			thread.Start();
			changeControlShow(label_testInfoLoading, true);
		}
		private void TestInfoProcessThread() {
			if (testInfoLoading) return;
			testInfoLoading = true;
			ListView view;
			while (true)
			{
				view = Info.getTestInfo();
				if (view == null)
				{
					if (MessageBox.Show("考试信息加载失败，请尝试重试", "加载失败",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
						continue;
				}
				else
				{
					addControlAction(panel_testInfo,view);
					testInfoIsLoad = true;
				}
				break;
			}
			testInfoLoading = false;
			changeControlShow(label_testInfoLoading, false);
		}

		private void tabPage_TestLevelInfo_Enter(object sender, EventArgs e)
		{
			if (testLevelIsLoad) return;
			TestLevelLoad();
		}
		private void TestLevelLoad() {
			panel_testLevel.Controls.Clear();
			Thread thread = new Thread(new ThreadStart(TestLevelProcessThread));
			thread.Start();
			changeControlShow(label_testLevelInfoLoading, true);
		}
		private void button_testLevelInfoRefresh_Click(object sender, EventArgs e)
		{
			TestLevelLoad();
		}
		private void TestLevelProcessThread()
		{
			if (testLevelLoading) return;
			testLevelLoading = true;
			ListView view;
			while (true)
			{
				view = Info.getTestLevelInfo();
				if (view == null)
				{
					if (MessageBox.Show("等级考试信息加载失败，请尝试重试", "加载失败",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
						continue;
				}
				else
				{
					addControlAction(panel_testLevel, view);
					testLevelIsLoad = true;
				}
				break;
			}
			testLevelLoading = false;
			changeControlShow(label_testLevelInfoLoading, false);
		}
	}
}
