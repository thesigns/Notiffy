# Notiffy 2.0

Notiffy is an ultra-minimalist app that sends notifications to the user in Windows.

The Notiffy interface consists of a single text field that can be minimized to the Windows Tray.

Everything in the text field that is not a notification definition is treated as a comment. Correctly formatted notifications are highlighted in green.

Below are examples of how to format notifications:

> 22:00 Time for bedtime!
> 
A notification with the text "Time for bedtime!" will appear every day at 10 PM.

> *.12.25 8:00 Christmas!
> 
A notification with the text "Christmas!" will appear every Christmas at 8 AM.

> +-+-+-- 8:30 Time to work!
>
A notification with the text "Time to work!" will appear on Monday, Tuesday, and Wednesday at 8:30 AM.

> *.5.* + - 8:00 Time to work!
> 
> *.5.* - -----++ 17:00 Time to work!
> 
A notification with the text "Time to work!" will appear in May on odd weeks at 8 AM and on even weeks during weekends at 5 PM.

That's all!

![Screenshot](/Notiffy/Resources/Screenshot.png?raw=true "Screenshot")

