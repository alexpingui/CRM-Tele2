   M S B A M L   `   `   `  ����D  @CRM Tele2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CRM_Tele2	CRM_Tele2  5   	       CRM_Tele2.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CRM_Tele2     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	CRM Tele2��5	   	   $	��800��6   $	��400��6(   $
��1100��68    � WindowStartupLocation$ CenterScreen=�6H    � 	Resources 5       �� 
TargetType �� Property �� Value��%5  '��       '�� r     �� 5   
   " ��6   .�5      ��  � ��$
 Wrap=�6-   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  �@��TextWrapping$
 Wrap=�6-   �� 5       �@��AcceptsReturn . 6.   �� 5       � ��$ Center=�62   5      5      .��5      �  � Cursor$  ��6    � ColumnDefinitions 5   
   �� 5      $��0.25* �6   $	��100��6-   $	��200��6<   5      �� 5      $��* �6   6,   .+�5    
   �� -   5         ��Name$ Pages��5       $��0��6$   
�������.+�5!      �� -   5        $��Добавить��5!      6(   �� 5"      -   5        $��Исходящий��5"      6)   5#      � 5%   
   $��1��6   .+�5&      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 mainDataGrid��5&      
   
IsReadOnly
 .    AutoGenerateColumns .    CanUserResizeRows . 5+      5,      5-      5.      