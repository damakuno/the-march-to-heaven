# The script of the game goes in this file.

# Declare characters used by this game. The color argument colorizes the
# name of the character.

image MC_default = "char/mc_Default.png"
image MC_sad = "char/mc_Sad.png"
image MC_happy = "char/mc_Happy.png"
image MC_talk = "char/mc_Talk.png"
image MC_worried = "char/mc_Worried.png"
define MC = Character("Sammy")


# The game starts here.

label start:

    # Show a background. This uses a placeholder by default, but you can
    # add a file (named either "bg room.png" or "bg room.jpg") to the
    # images directory to show it.

    scene bg room

    # This shows a character sprite. A placeholder is used, but you can
    # replace it by adding a file named "eileen happy.png" to the images
    # directory.

    show MC_default
    # These display lines of dialogue.
    
    MC "How you doing sis?  The doctor says you should be up and about in a few days. I know the \"results\" were pretty hard to take, but... I'm sure it'll be better once you wake up."
menu:

    "Yes":                
        jump option1_yes
    "No":
        jump option1_no

    # show MC_talk

    # MC "Once you add a story, pictures, and music, you can release it to the world!"


label option1_yes:    
    show MC_happy
    MC "You chose option 1"
    jump option1_done

label option1_no:
    show MC_talk
    MC "You chose option 2"
    jump option1_done


label option1_done:
    # This ends the game.
    show MC_talk
    MC "Great!"
    return

