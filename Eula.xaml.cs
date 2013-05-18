using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Bitdozer
{
    public partial class Eula : UserControl
    {
        public Eula()
        {
            InitializeComponent();
            tbEULAText.Text = EULAText;
            tbEULAText2.Text = EULAText2;
        }

        public static String EULAText = "\n\nEND-USER LICENSE AGREEMENT FOR\n\nBitDozer\n\nIMPORTANT PLEASE READ THE TERMS AND CONDITIONS OF THIS LICENSE AGREEMENT CAREFULLY BEFORE CONTINUING WITH THIS PROGRAM INSTALL:\n\n Tagelmoust LLC End-User License Agreement (\"EULA\") is a legal agreement between you (either an individual or a single entity) and Tagelmoust LLC for the Tagelmoust LLC software product(s) identified above which may include associated software components, media, printed materials, and \"online\" or electronic documentation (\"SOFTWARE PRODUCT\"). By installing, copying, or otherwise using the SOFTWARE PRODUCT, you agree to be bound by the terms of this EULA. This license agreement represents the entire agreement concerning the program between you and Tagelmoust LLC, (referred to as \"licenser\"), and it supersedes any prior proposal, representation, or understanding between the parties. If you do not agree to the terms of this EULA, do not install or use the SOFTWARE PRODUCT. \n" + 
                                 "The SOFTWARE PRODUCT is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. The SOFTWARE PRODUCT is licensed, not sold. \n" +
                                 "1. GRANT OF LICENSE. \n"+
                                 "\n" +
                                 "The SOFTWARE PRODUCT uses the Gecko~Fawkes~License and is licensed as follows:\n" +
                                 "(a) Installation and Use.\n" +
                                 "Tagelmoust LLC grants you the right to install and use copies of the SOFTWARE PRODUCT on your computer running a validly licensed copy of the operating system for which the SOFTWARE PRODUCT was designed [e.g., Windows 95, Windows NT, Windows 98, Windows 2000, Windows 2003, Windows XP, Windows ME, Windows Vista].\n" +
                                 "(b) Backup Copies.\n" +
                                 "You may also make copies of the SOFTWARE PRODUCT as may be necessary for backup and archival purposes.\n" +
                                 "\n" +
                                 "2. DESCRIPTION OF OTHER RIGHTS AND LIMITATIONS.\n" +
                                 "(a) Maintenance of Copyright Notices.\n" +
                                 "You must not remove or alter any copyright notices on any and all copies of the SOFTWARE PRODUCT.\n" +
                                 "(b) Distribution.\n" +
                                 "You may not distribute registered copies of the SOFTWARE PRODUCT to third parties. Evaluation versions available for download from Tagelmoust LLC's websites may be freely distributed.\n" +
                                 "(c) Prohibition on Reverse Engineering, Decompilation, and Disassembly.\n" +
                                 "You may not reverse engineer, decompile, or disassemble the SOFTWARE PRODUCT, except and only to the extent that such activity is expressly permitted by applicable law notwithstanding this limitation.\n" +
                                 "(d) Rental.\n" +
                                 "You may not rent, lease, or lend the SOFTWARE PRODUCT.\n" +
                                 "(e) Support Services.\n" +
                                 "Tagelmoust LLC may provide you with support services related to the SOFTWARE PRODUCT (\"Support Services\"). Any supplemental software code provided to you as part of the Support Services shall be considered part of the SOFTWARE PRODUCT and subject to the terms and conditions of this EULA.\n" +
                                 "(f) Compliance with Applicable Laws.\n" +
                                 "You must comply with all applicable laws regarding use of the SOFTWARE PRODUCT.\n";

        public static String EULAText2 = "3. TERMINATION\n" +
                                 "Without prejudice to any other rights, Tagelmoust LLC may terminate this EULA if you fail to comply with the terms and conditions of this EULA. In such event, you must destroy all copies of the SOFTWARE PRODUCT in your possession.\n" +
                                 "\n" +
                                 "4. COPYRIGHT\n" +
                                 "All title, including but not limited to copyrights, in and to the SOFTWARE PRODUCT and any copies thereof are owned by Tagelmoust LLC or its suppliers. All title and intellectual property rights in and to the content which may be accessed through use of the SOFTWARE PRODUCT is the property of the respective content owner and may be protected by applicable copyright or other intellectual property laws and treaties. This EULA grants you no rights to use such content. All rights not expressly granted are reserved by Tagelmoust LLC.\n" +
                                 "\n" +
                                 "5. NO WARRANTIES\n" +
                                 "Tagelmoust LLC expressly disclaims any warranty for the SOFTWARE PRODUCT. The SOFTWARE PRODUCT is provided 'As Is' without any express or implied warranty of any kind, including but not limited to any warranties of merchantability, noninfringement, or fitness of a particular purpose. Tagelmoust LLC does not warrant or assume responsibility for the accuracy or completeness of any information, text, graphics, links or other items contained within the SOFTWARE PRODUCT. Tagelmoust LLC makes no warranties respecting any harm that may be caused by the transmission of a computer virus, worm, time bomb, logic bomb, or other such computer program. Tagelmoust LLC further expressly disclaims any warranty or representation to Authorized Users or to any third party.\n" +
                                 "\n" +
                                 "6. LIMITATION OF LIABILITY\n" +
                                 "In no event shall Tagelmoust LLC be liable for any damages (including, without limitation, lost profits, business interruption, or lost information) rising out of 'Authorized Users' use of or inability to use the SOFTWARE PRODUCT, even if Tagelmoust LLC has been advised of the possibility of such damages. In no event will Tagelmoust LLC be liable for loss of data or for indirect, special, incidental, consequential (including lost profit), or other damages based in contract, tort or otherwise. Tagelmoust LLC shall have no liability with respect to the content of the SOFTWARE PRODUCT or any part thereof, including but not limited to errors or omissions contained therein, libel, infringements of rights of publicity, privacy, trademark rights, business interruption, personal injury, loss of privacy, moral rights or the disclosure of confidential information.";

        private void btnAcceptEULA_Click(object sender, RoutedEventArgs e)
        {
            ((BitDozer)BitDozer.Current).CloseEULA();
        }

    }
}
