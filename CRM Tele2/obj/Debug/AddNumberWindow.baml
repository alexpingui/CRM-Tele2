   M S B A M L   `   `   `  ����D  @CRM Tele2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CRM_Tele2	CRM_Tele2  5   	       CRM_Tele2.AddNumberWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CRM_Tele2     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AddNumberWindow��5	   	   $	��370��6!   $	��399��61   $
��1080��6>   $	��450��6O   $	��450��6[   $
��1000��6j    � WindowStartupLocation$ CenterScreen=�6z    � WindowStyle$ 
ToolWindow=�6�   .��5
      � .+�5   
   �� $��20q�6   ���#eeeeee �� CornerRadius$ 20��5   &    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightBlue��63      ShadowDepth$ 0Q�6E   ._�5      �� -   5         ��Name$ controlsPanel��5      $��20q�60   .+�5      �� $%��Введите значения��6   $
��Bold"�64   $��20(�5      �� 5      -   5        	 ��Name$
	 name��5      $��0 10 0 0q�6(   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Введите имя��6:    %  !MaterialDesignFloatingHintTextBox#��[  5      �� 5      -   5        $	 phoneNumber��5      $
 Введите номер��60   #��[  5      $	��+77��5       �� 	MaxLength$ 12��5      �� 5      -   5        $	 adress��5      $
 Введите адрес��6+   #��[  5      �� 5      -   5        $	 comment��5      $
��0 10q�6+   $
 Комментарий��69    �� TextWrapping$
 Wrap=�5       �� MinLines$ 2��60   (  "System.Windows.Controls.DatePicker  5       -   5          Name$ dateOfScheduledCall��5       $%
 Назначить звонок��6:   �� 5#      -   5         ��Name$ 	AddPerson��5#      $��Добавить��6,   ���#75a8fa6T   5$      5(      5)      5*      