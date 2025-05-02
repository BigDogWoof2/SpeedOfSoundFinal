/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMB_ENGINESTART = 2354163696U;
        static const AkUniqueID AMB_ENGINESTOP = 3934538588U;
        static const AkUniqueID AMB_POLICESIREN = 3406798923U;
        static const AkUniqueID AMB_WIND = 1439088316U;
        static const AkUniqueID BGM_START_SPEEDOFSOUND = 3940797748U;
        static const AkUniqueID BGM_STARTUPJINGLE = 1281301044U;
        static const AkUniqueID BGM_STOPTITLESCREENMUSIC = 26516739U;
        static const AkUniqueID BGM_TITLESCREENMUSIC = 2278664411U;
        static const AkUniqueID DEBUGBEEP = 2928919970U;
        static const AkUniqueID SFX_GEARSHIFT = 3708240220U;
        static const AkUniqueID SFX_NOTEDECENT = 2547397398U;
        static const AkUniqueID SFX_NOTEMISS = 1870322745U;
        static const AkUniqueID SFX_NOTEPERFECT = 4070368520U;
        static const AkUniqueID SFX_NOTEPRESS = 1771235554U;
        static const AkUniqueID SFX_SWITCHLANE = 1302786983U;
        static const AkUniqueID UI_BUTTONHOVER = 2027123568U;
        static const AkUniqueID UI_CONTEXTCLOSE = 4003678909U;
        static const AkUniqueID UI_CONTEXTOPEN = 1475854423U;
        static const AkUniqueID UI_NEWGAME = 2240351934U;
        static const AkUniqueID UI_QUIT = 4273572087U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace BGM_LEVEL
        {
            static const AkUniqueID GROUP = 3727984986U;

            namespace STATE
            {
                static const AkUniqueID HIGH = 3550808449U;
                static const AkUniqueID LOW = 545371365U;
                static const AkUniqueID MEDIUM = 2849147824U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace BGM_LEVEL

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PERFECTCOMBO = 1517363770U;
        static const AkUniqueID POLICEDISTANCE = 1887703654U;
        static const AkUniqueID RPM = 796049864U;
        static const AkUniqueID WINDSPEED = 1726592700U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB_OUTSIDE = 2098287461U;
        static const AkUniqueID REVERB_SIREN = 2041057431U;
        static const AkUniqueID REVERB_TUNNEL = 2261546958U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
