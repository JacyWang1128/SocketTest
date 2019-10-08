eyeview_eyecontrol

this is an example implemented in c# to show process view and control of eyevision from an external program.

Required:
.Net 4.5 framework 
EyeVision_Win32_V3.5.010

The resulting application depends on several EyeVision libraries. These are searched in parallel to the application. For working execution copy the application to an EyeVision<version>/bin folder or set the path veriable.

Eyevision

exec/kill button : execute/kill the EyeVision.exe, it is executed minimized.

EyeView

EyeView can use UDP socket or sharedmemory as transfer channel. 

These settings need to match in EyeVision command image transfer and EyeView.

Transfer over UDP 
source ip :port  : IP of the sender network device. If sender and receiver are on the same system also localhost 127.0.0.1 is possible. Port is the local port selected in image transfer command
Port : receive port, standard is 4557 : not changeable in gui.

Transfer over sharedmemory

In EyeVision command image tranfer an index is selected. In EyeView this index translates to an IP address. Index 0 = 127.0.0.10, index 1 = 127.0.0.11, index 245 = 127.0.0.255 
Local Port : allways 1000
Port : dont care.

start/stop button : start listening for image tansfer packets on the two defined addresses

EyeControl

server ip: port : PConLan TCP server address. Check EyeVision_config.ini for the following settings.

[ProgramControl.TCP]
	Enabled = 1
	Port = 5953

connect/disconnect button : connect to PConLan TCP server

start button : start loaded checkprogram
stop button : stop loaded checkprogram
once button : run loaded checkprogram once
hide/show button : hide/show EyeVision

command1,2,3,4; send : PConLan command lines

Example command1 : switch checkprogram to transfer_mix_gs.ckp
Example command2 : maximize eyevision

Global String

one way to get information out of the checkprogram to an other process is sending text as network packets. This example uses a TCP server that receives the text and displays it in a textbox.

start/stop button : start/stop the tcp server.

20170817THR

