public enum LogEventIdEnum

{
    /*   12 */
    STR_NULL(Integer.valueOf(0), "STR_NULL"),
    /*   13 */
    STR_HOME_PAGE(Integer.valueOf(1), "STR_HOME_PAGE"),
    /*   14 */
    STR_ENTER_INFUSION(Integer.valueOf(2), "STR_ENTER_INFUSION"),
    /*   15 */
    STR_VIEW_REPORT(Integer.valueOf(3), "STR_VIEW_REPORT"),
    /*   16 */
    STR_INFUSION_MODE(Integer.valueOf(4), "STR_INFUSION_MODE"),
    /*   17 */
    STR_NEW_INFUSION(Integer.valueOf(5), "STR_NEW_INFUSION"),
    /*   18 */
    STR_LAST_INFUS(Integer.valueOf(6), "STR_LAST_INFUS"),
    /*   19 */
    STR_PRESET_PROGRAM(Integer.valueOf(7), "STR_PRESET_PROGRAM"),
    /*   20 */
    STR_PRIME(Integer.valueOf(8), "STR_PRIME"),
    /*   21 */
    STR_QUIT(Integer.valueOf(9), "STR_QUIT"),
    /*   22 */
    STR_STOP_PRIME(Integer.valueOf(10), "STR_STOP_PRIME"),
    /*   23 */
    STR_BACK(Integer.valueOf(11), "STR_BACK"),
    /*   24 */
    STR_OK(Integer.valueOf(12), "STR_OK"),
    /*   25 */
    STR_RATE_MODE(Integer.valueOf(13), "STR_RATE_MODE"),
    /*   26 */
    STR_TIME(Integer.valueOf(14), "STR_TIME"),
    /*   27 */
    STR_RATE(Integer.valueOf(15), "STR_RATE"),
    /*   28 */
    STR_VOL_INFUSED(Integer.valueOf(16), "STR_VOL_INFUSED"),
    /*   29 */
    STR_PRIME_TIP(Integer.valueOf(17), "STR_PRIME_TIP"),
    /*   30 */
    STR_YES(Integer.valueOf(18), "STR_YES"),
    /*   31 */
    STR_NO(Integer.valueOf(19), "STR_NO"),
    /*   32 */
    STR_BOLUS_SETTING(Integer.valueOf(20), "STR_BOLUS_SETTING"),
    /*   33 */
    STR_BOLUS_RATE(Integer.valueOf(21), "STR_BOLUS_RATE"),
    /*   34 */
    STR_BOLUS_VTBI(Integer.valueOf(22), "STR_BOLUS_VTBI"),
    /*   35 */
    STR_BOLUS_TIME(Integer.valueOf(23), "STR_BOLUS_TIME"),
    /*   36 */
    STR_INPUT_ERROR(Integer.valueOf(24), "STR_INPUT_ERROR"),
    /*   37 */
    STR_PWD_ERROR(Integer.valueOf(25), "STR_PWD_ERROR"),
    /*   38 */
    STR_OPTION_TP(Integer.valueOf(26), "STR_OPTION_TP"),
    /*   39 */
    STR_IS_QUIT_SET(Integer.valueOf(27), "STR_IS_QUIT_SET"),
    /*   40 */
    STR_ML(Integer.valueOf(28), "STR_ML"),
    /*   41 */
    STR_MLH(Integer.valueOf(29), "STR_MLH"),
    /*   42 */
    STR_PRIME_VOL(Integer.valueOf(30), "STR_PRIME_VOL"),
    /*   43 */
    STR_KVO(Integer.valueOf(31), "STR_KVO"),
    /*   44 */
    STR_KVO_RATE(Integer.valueOf(32), "STR_KVO_RATE"),
    /*   45 */
    STR_BOLUS(Integer.valueOf(33), "STR_BOLUS"),
    /*   46 */
    STR_ALARM_AUDIO_PAUSE(Integer.valueOf(34), "STR_ALARM_AUDIO_PAUSE"),
    /*   47 */
    STR_ALARM_ACKNOWLEDGE(Integer.valueOf(35), "STR_ALARM_ACKNOWLEDGE"),
    /*   48 */
    STR_ALARM_INFUSION_COMPLETE(Integer.valueOf(36), "STR_ALARM_INFUSION_COMPLETE"),
    /*   49 */
    STR_HELP_ALARM_INFUSION_COMPLETE(Integer.valueOf(37), "STR_HELP_ALARM_INFUSION_COMPLETE"),
    /*   50 */
    STR_ALARM_INFUSION_COMPLETE_KVO_START(Integer.valueOf(38), "STR_ALARM_INFUSION_COMPLETE_KVO_START"),
    /*   51 */
    STR_HELP_ALARM_INFUSION_COMPLETE_KVO_START(Integer.valueOf(39), "STR_HELP_ALARM_INFUSION_COMPLETE_KVO_START"),
    /*   52 */
    STR_ALARM_INFUSION_NEAR_COMPLETE(Integer.valueOf(40), "STR_ALARM_INFUSION_NEAR_COMPLETE"),
    /*   53 */
    STR_HELP_ALARM_INFUSION_NEAR_COMPLETE(Integer.valueOf(41), "STR_HELP_ALARM_INFUSION_NEAR_COMPLETE"),
    /*   54 */
    STR_ALARM_NO_BAT(Integer.valueOf(42), "STR_ALARM_NO_BAT"),
    /*   55 */
    STR_HELP_ALARM_NO_BAT(Integer.valueOf(43), "STR_HELP_ALARM_NO_BAT"),
    /*   56 */
    STR_ALARM_NO_ACPOWER(Integer.valueOf(44), "STR_ALARM_NO_ACPOWER"),
    /*   57 */
    STR_HELP_ALARM_NO_ACPOWER(Integer.valueOf(45), "STR_HELP_ALARM_NO_ACPOWER"),
    /*   58 */
    STR_ALARM_NO_POWER(Integer.valueOf(46), "STR_ALARM_NO_POWER"),
    /*   59 */
    STR_HELP_ALARM_BAT_OFF(Integer.valueOf(47), "STR_HELP_ALARM_BAT_OFF"),
    /*   60 */
    STR_ALARM_CASSETTE_DETACHED(Integer.valueOf(48), "STR_ALARM_CASSETTE_DETACHED"),
    /*   61 */
    STR_ALARM_RESERVOIR_UNLOCK(Integer.valueOf(49), "STR_ALARM_RESERVOIR_UNLOCK"),
    /*   62 */
    STR_ALARM_BUTTON_FAULT(Integer.valueOf(50), "STR_ALARM_BUTTON_FAULT"),
    /*   63 */
    STR_HELP_ALARM_BUTTON_FAULT(Integer.valueOf(51), "STR_HELP_ALARM_BUTTON_FAULT"),
    /*   64 */
    STR_ALARM_FORGET_OPERATION(Integer.valueOf(52), "STR_ALARM_FORGET_OPERATION"),
    /*   65 */
    STR_HELP_ALARM_FORGET_OPERATION(Integer.valueOf(53), "STR_HELP_ALARM_FORGET_OPERATION"),
    /*   66 */
    STR_ALARM_DOWNSTREAM_OCCL(Integer.valueOf(54), "STR_ALARM_DOWNSTREAM_OCCL"),
    /*   67 */
    STR_HELP_ALARM_DOWNSTREAM_OCCL(Integer.valueOf(55), "STR_HELP_ALARM_DOWNSTREAM_OCCL"),
    /*   68 */
    STR_ALARM_UPSTREAM_OCCL(Integer.valueOf(56), "STR_ALARM_UPSTREAM_OCCL"),
    /*   69 */
    STR_HELP_ALARM_UPSTREAM_OCCL(Integer.valueOf(57), "STR_HELP_ALARM_UPSTREAM_OCCL"),
    /*   70 */
    STR_ALARM_BUBBLE_EXIST(Integer.valueOf(58), "STR_ALARM_BUBBLE_EXIST"),
    /*   71 */
    STR_HELP_ALARM_BUBBLE_EXIST(Integer.valueOf(59), "STR_HELP_ALARM_BUBBLE_EXIST"),
    /*   72 */
    STR_ALARM_STBY_END(Integer.valueOf(60), "STR_ALARM_STBY_END"),
    /*   73 */
    STR_HELP_ALARM_STBY_END(Integer.valueOf(61), "STR_HELP_ALARM_STBY_END"),
    /*   74 */
    STR_ALARM_PCA_DOSE_CONTROLLER_REMOVE(Integer.valueOf(62), "STR_ALARM_PCA_DOSE_CONTROLLER_REMOVE"),
    /*   75 */
    STR_HELP_ALARM_PCA_DOSE_CONTROLLER_REMOVE(Integer.valueOf(63), "STR_HELP_ALARM_PCA_DOSE_CONTROLLER_REMOVE"),
    /*   76 */
    STR_ALARM_COM_INTERRUPTED(Integer.valueOf(64), "STR_ALARM_COM_INTERRUPTED"),
    /*   77 */
    STR_HELP_ALARM_COM_INTERRUPTED(Integer.valueOf(65), "STR_HELP_ALARM_COM_INTERRUPTED"),
    /*   78 */
    STR_ALARM_BAT_EMPTY(Integer.valueOf(66), "STR_ALARM_BAT_EMPTY"),
    /*   79 */
    STR_HELP_ALARM_BAT_EMPTY(Integer.valueOf(67), "STR_HELP_ALARM_BAT_EMPTY"),
    /*   80 */
    STR_ALARM_BAT_LOW(Integer.valueOf(68), "STR_ALARM_BAT_LOW"),
    /*   81 */
    STR_HELP_ALARM_BAT_LOW(Integer.valueOf(69), "STR_HELP_ALARM_BAT_LOW"),
    /*   82 */
    STR_ALARM_TONE_SET(Integer.valueOf(70), "STR_ALARM_TONE_SET"),
    /*   83 */
    STR_ALARM_TONE_HIGH(Integer.valueOf(71), "STR_ALARM_TONE_HIGH"),
    /*   84 */
    STR_ALARM_TONE_MEDIUM(Integer.valueOf(72), "STR_ALARM_TONE_MEDIUM"),
    /*   85 */
    STR_ALARM_TONE_LOW(Integer.valueOf(73), "STR_ALARM_TONE_LOW"),
    /*   86 */
    STR_REMINDER_ALARM_TIME(Integer.valueOf(74), "STR_REMINDER_ALARM_TIME"),
    /*   87 */
    STR_LEVEL_LOW(Integer.valueOf(75), "STR_LEVEL_LOW"),
    /*   88 */
    STR_LEVEL_MED(Integer.valueOf(76), "STR_LEVEL_MED"),
    /*   89 */
    STR_ADJUST_INTENSITY(Integer.valueOf(77), "STR_ADJUST_INTENSITY"),
    /*   90 */
    STR_LOCAL_SET(Integer.valueOf(78), "STR_LOCAL_SET"),
    /*   91 */
    STR_BUBBLE_SINGLE_VOL(Integer.valueOf(79), "STR_BUBBLE_SINGLE_VOL"),
    /*   92 */
    STR_BUBBLE_TOTAL_VOL(Integer.valueOf(80), "STR_BUBBLE_TOTAL_VOL"),
    /*   93 */
    STR_OCCL_LEVEL(Integer.valueOf(81), "STR_OCCL_LEVEL"),
    /*   94 */
    STR_PRESSURE_UNIT(Integer.valueOf(82), "STR_PRESSURE_UNIT"),
    /*   95 */
    STR_PRESSURE_UNIT_MMHG(Integer.valueOf(83), "STR_PRESSURE_UNIT_MMHG"),
    /*   96 */
    STR_PRESSURE_UNIT_KPA(Integer.valueOf(84), "STR_PRESSURE_UNIT_KPA"),
    /*   97 */
    STR_PRESSURE_UNIT_PSI(Integer.valueOf(85), "STR_PRESSURE_UNIT_PSI"),
    /*   98 */
    STR_PRESSURE_UNIT_BAR(Integer.valueOf(86), "STR_PRESSURE_UNIT_BAR"),
    /*   99 */
    STR_REALTIME_PRESSURE(Integer.valueOf(87), "STR_REALTIME_PRESSURE"),
    /*  100 */
    STR_ALARM_SET(Integer.valueOf(88), "STR_ALARM_SET"),
    /*  101 */
    STR_SYSTEM_SET(Integer.valueOf(89), "STR_SYSTEM_SET"),
    /*  102 */
    STR_NEXT_PAGE(Integer.valueOf(90), "STR_NEXT_PAGE"),
    /*  103 */
    STR_PRE_PAGE(Integer.valueOf(91), "STR_PRE_PAGE"),
    /*  104 */
    STR_INFUSION_SET(Integer.valueOf(92), "STR_INFUSION_SET"),
    /*  105 */
    STR_DEVICE_INFO(Integer.valueOf(93), "STR_DEVICE_INFO"),
    /*  106 */
    STR_GENERAL_SET(Integer.valueOf(94), "STR_GENERAL_SET"),
    /*  107 */
    STR_USER_MAINTENANCE(Integer.valueOf(95), "STR_USER_MAINTENANCE"),
    /*  108 */
    STR_FACTORY_MAINTENANCE(Integer.valueOf(96), "STR_FACTORY_MAINTENANCE"),
    /*  109 */
    STR_REMINDER_ALARM_LEVEL(Integer.valueOf(97), "STR_REMINDER_ALARM_LEVEL"),
    /*  110 */
    STR_PCA_SET(Integer.valueOf(98), "STR_PCA_SET"),
    /*  111 */
    STR_OCCL_SET(Integer.valueOf(99), "STR_OCCL_SET"),
    /*  112 */
    STR_BUBBLE_SET(Integer.valueOf(100), "STR_BUBBLE_SET"),
    /*  113 */
    STR_DRUG_COMMON(Integer.valueOf(101), "STR_DRUG_COMMON"),
    /*  114 */
    STR_PCA_MODE(Integer.valueOf(102), "STR_PCA_MODE"),
    /*  115 */
    STR_PCS_MODE(Integer.valueOf(103), "STR_PCS_MODE"),
    /*  116 */
    STR_PIEB_MODE(Integer.valueOf(104), "STR_PIEB_MODE"),
    /*  117 */
    STR_DRUG_CONCENTRATION(Integer.valueOf(105), "STR_DRUG_CONCENTRATION"),
    /*  118 */
    STR_VTBI(Integer.valueOf(106), "STR_VTBI"),
    /*  119 */
    STR_LOCKOUT_TIME(Integer.valueOf(107), "STR_LOCKOUT_TIME"),
    /*  120 */
    STR_PCA_VTBI_HOUR(Integer.valueOf(108), "STR_PCA_VTBI_HOUR"),
    /*  121 */
    STR_VTBI_LIMIT_EXC(Integer.valueOf(109), "STR_VTBI_LIMIT_EXC"),
    /*  122 */
    STR_OPERATION(Integer.valueOf(110), "STR_OPERATION"),
    /*  123 */
    STR_PCA_PRESS_COUNT(Integer.valueOf(111), "STR_PCA_PRESS_COUNT"),
    /*  124 */
    STR_PCA_COUNT_MODE_SUM(Integer.valueOf(112), "STR_PCA_COUNT_MODE_SUM"),
    /*  125 */
    STR_INFUSION_RATE(Integer.valueOf(113), "STR_INFUSION_RATE"),
    /*  126 */
    STR_PCA_VALID_TIMES_PER_PCA_TOTAL_TIMES(Integer.valueOf(114), "STR_PCA_VALID_TIMES_PER_PCA_TOTAL_TIMES"),
    /*  127 */
    STR_PCA_INVALID_TIMES(Integer.valueOf(115), "STR_PCA_INVALID_TIMES"),
    /*  128 */
    STR_SPO2(Integer.valueOf(116), "STR_SPO2"),
    /*  129 */
    STR_PR(Integer.valueOf(117), "STR_PR"),
    /*  130 */
    STR_STANDBY_TIME(Integer.valueOf(118), "STR_STANDBY_TIME"),
    /*  131 */
    STR_AUTOMATIC(Integer.valueOf(119), "STR_AUTOMATIC"),
    /*  132 */
    STR_AUTOMATIC_BRIGTHNESS(Integer.valueOf(120), "STR_AUTOMATIC_BRIGTHNESS"),
    /*  133 */
    STR_NEW_PATIENT(Integer.valueOf(121), "STR_NEW_PATIENT"),
    /*  134 */
    STR_SCREEN_BRINGTNESS(Integer.valueOf(122), "STR_SCREEN_BRINGTNESS"),
    /*  135 */
    STR_EQUIPMENT_ERROR(Integer.valueOf(123), "STR_EQUIPMENT_ERROR"),
    /*      */
    /*  137 */
    STR_INFUSION_ENDED_PARAMETERS_CLEARED(Integer.valueOf(124), "STR_INFUSION_ENDED_PARAMETERS_CLEARED"),
    /*      */
    /*  139 */
    STR_ALARM_PURGE_START_FAIL(Integer.valueOf(125), "STR_ALARM_PURGE_START_FAIL"),
    /*      */
    /*  141 */
    STR_ALARM_INFUSION_START_FAIL(Integer.valueOf(126), "STR_ALARM_INFUSION_START_FAIL"),
    /*      */
    /*  143 */
    STR_SCREEN_LEFT_TIME(Integer.valueOf(127), "STR_SCREEN_LEFT_TIME"),
    /*  144 */
    STR_SCREEN_PIEB_NEXT_BOLUS(Integer.valueOf(128), "STR_SCREEN_PIEB_NEXT_BOLUS"),
    /*  145 */
    STR_SCREEN_PIEB_INT(Integer.valueOf(129), "STR_SCREEN_PIEB_INT"),
    /*  146 */
    STR_LOADING_DOSE(Integer.valueOf(130), "STR_LOADING_DOSE"),
    /*  147 */
    STR_SCREEN_PIEB_DOSE(Integer.valueOf(131), "STR_SCREEN_PIEB_DOSE"),
    /*  148 */
    STR_SCREEN_PIEB_INTERVAL(Integer.valueOf(132), "STR_SCREEN_PIEB_INTERVAL"),
    /*  149 */
    STR_CONTINUOUS_RATE(Integer.valueOf(133), "STR_CONTINUOUS_RATE"),
    /*  150 */
    STR_SWITCH_DOSE_LMT(Integer.valueOf(134), "STR_SWITCH_DOSE_LMT"),
    /*  151 */
    STR_DOSE_LMT_HOURS(Integer.valueOf(135), "STR_DOSE_LMT_HOURS"),
    /*  152 */
    STR_EXIST_HIGH_ALARM(Integer.valueOf(136), "STR_EXIST_HIGH_ALARM"),
    /*  153 */
    STR_PIEB_SET(Integer.valueOf(137), "STR_PIEB_SET"),
    /*  154 */
    STR_PIEB_INTERVAL_TYPE(Integer.valueOf(138), "STR_PIEB_INTERVAL_TYPE"),
    /*  155 */
    STR_TIME_MODE(Integer.valueOf(139), "STR_TIME_MODE"),
    /*  156 */
    STR_WEIGHT_MODE(Integer.valueOf(140), "STR_WEIGHT_MODE"),
    /*  157 */
    STR_SEQUENCE_MODE(Integer.valueOf(141), "STR_SEQUENCE_MODE"),
    /*  158 */
    STR_INTERMITTENT_MODE(Integer.valueOf(142), "STR_INTERMITTENT_MODE"),
    /*  159 */
    STR_TRAPEZIA_MODE(Integer.valueOf(143), "STR_TRAPEZIA_MODE"),
    /*  160 */
    STR_PCEA_MODE(Integer.valueOf(144), "STR_PCEA_MODE"),
    /*  161 */
    STR_PCEA_SET(Integer.valueOf(145), "STR_PCEA_SET"),
    /*  162 */
    STR_PCS_SET(Integer.valueOf(146), "STR_PCS_SET"),
    /*  163 */
    STR_HINT_FRAME_PLEASE_CONFIRM(Integer.valueOf(147), "STR_HINT_FRAME_PLEASE_CONFIRM"),
    /*  164 */
    STR_MIN(Integer.valueOf(148), "STR_MIN"),
    /*  165 */
    STR_INFUSION_PARAMETER_PIEB_DOSE(Integer.valueOf(149), "STR_INFUSION_PARAMETER_PIEB_DOSE"),
    /*  166 */
    STR_INFUSION_PARAMETER_PIEB_INTERVAL(Integer.valueOf(150), "STR_INFUSION_PARAMETER_PIEB_INTERVAL"),
    /*  167 */
    STR_ALARM_PCA_DOSE_LIMIT_EXCEEDED(Integer.valueOf(151), "STR_ALARM_PCA_DOSE_LIMIT_EXCEEDED"),
    /*  168 */
    STR_INFUSION_PARAMETER_PCA_DOSE(Integer.valueOf(152), "STR_INFUSION_PARAMETER_PCA_DOSE"),
    /*  169 */
    STR_HINT_FRAME_PARAMETERS_CHECKED_INFUSION_STARTED(Integer.valueOf(153), "STR_HINT_FRAME_PARAMETERS_CHECKED_INFUSION_STARTED"),
    /*  170 */
    STR_UNIT_TIMES(Integer.valueOf(154), "STR_UNIT_TIMES"),
    /*  171 */
    STR_BOLUS_LESS_THAN_INFUSE(Integer.valueOf(155), "STR_BOLUS_LESS_THAN_INFUSE"),
    /*  172 */
    STR_PCEA_OOCL_CHANGED(Integer.valueOf(156), "STR_PCEA_OOCL_CHANGED"),
    /*  173 */
    STR_SURPLUS_VOLUME(Integer.valueOf(157), "STR_SURPLUS_VOLUME"),
    /*  174 */
    STR_NO_PAIN(Integer.valueOf(158), "STR_NO_PAIN"),
    /*  175 */
    STR_MILD_PAIN(Integer.valueOf(159), "STR_MILD_PAIN"),
    /*  176 */
    STR_MODERATE_PAIN(Integer.valueOf(160), "STR_MODERATE_PAIN"),
    /*  177 */
    STR_SEVERE_PAIN(Integer.valueOf(161), "STR_SEVERE_PAIN"),
    /*  178 */
    STR_BSA(Integer.valueOf(162), "STR_BSA"),
    /*  179 */
    STR_DUBOIS(Integer.valueOf(163), "STR_DUBOIS"),
    /*  180 */
    STR_STEVENSON(Integer.valueOf(164), "STR_STEVENSON"),
    /*  181 */
    STR_HEIGHT(Integer.valueOf(165), "STR_HEIGHT"),
    /*  182 */
    STR_WEIGHT(Integer.valueOf(166), "STR_WEIGHT"),
    /*  183 */
    STR_UNIT_CM(Integer.valueOf(167), "STR_UNIT_CM"),
    /*  184 */
    STR_DOSE_RATE(Integer.valueOf(168), "STR_DOSE_RATE"),
    /*  185 */
    STR_WHETHER_CYCLE(Integer.valueOf(169), "STR_WHETHER_CYCLE"),
    /*  186 */
    STR_S(Integer.valueOf(170), "STR_S"),
    /*  187 */
    STR_PAIN_SCORE_COMPLETED(Integer.valueOf(171), "STR_PAIN_SCORE_COMPLETED"),
    /*  188 */
    STR_DRUG_AMOUNT(Integer.valueOf(172), "STR_DRUG_AMOUNT"),
    /*  189 */
    STR_DRUG_VOLUME(Integer.valueOf(173), "STR_DRUG_VOLUME"),
    /*  190 */
    STR_AFTER(Integer.valueOf(174), "STR_AFTER"),
    /*  191 */
    STR_DATE_FORMAT(Integer.valueOf(175), "STR_DATE_FORMAT"),
    /*  192 */
    STR_Y_M_D(Integer.valueOf(176), "STR_Y_M_D"),
    /*  193 */
    STR_M_D_Y(Integer.valueOf(177), "STR_M_D_Y"),
    /*  194 */
    STR_D_M_Y(Integer.valueOf(178), "STR_D_M_Y"),
    /*  195 */
    STR_24H_SYSTEM(Integer.valueOf(179), "STR_24H_SYSTEM"),
    /*  196 */
    STR_UNIT_AM(Integer.valueOf(180), "STR_UNIT_AM"),
    /*  197 */
    STR_UNIT_PM(Integer.valueOf(181), "STR_UNIT_PM"),
    /*  198 */
    STR_UNIT_H(Integer.valueOf(182), "STR_UNIT_H"),
    /*  199 */
    STR_UNIT_MIN(Integer.valueOf(183), "STR_UNIT_MIN"),
    /*  200 */
    STR_UNIT_Y(Integer.valueOf(184), "STR_UNIT_Y"),
    /*  201 */
    STR_UNIT_M(Integer.valueOf(185), "STR_UNIT_M"),
    /*  202 */
    STR_UNIT_D(Integer.valueOf(186), "STR_UNIT_D"),
    /*  203 */
    STR_TIME_LANGUAGE(Integer.valueOf(187), "STR_TIME_LANGUAGE"),
    /*  204 */
    STR_DATE_SET(Integer.valueOf(188), "STR_DATE_SET"),
    /*  205 */
    STR_TIME_SET(Integer.valueOf(189), "STR_TIME_SET"),
    /*  206 */
    STR_CLEAR(Integer.valueOf(190), "STR_CLEAR"),
    /*  207 */
    STR_HOUR(Integer.valueOf(191), "STR_HOUR"),
    /*  208 */
    STR_MINUTE(Integer.valueOf(192), "STR_MINUTE"),
    /*  209 */
    STR_SECOND(Integer.valueOf(193), "STR_SECOND"),
    /*  210 */
    STR_SEQUENCE_NO(Integer.valueOf(194), "STR_SEQUENCE_NO"),
    /*  211 */
    STR_KEYPAD_PWD(Integer.valueOf(195), "STR_KEYPAD_PWD"),
    /*  212 */
    STR_CLINICIAN_PWD(Integer.valueOf(196), "STR_CLINICIAN_PWD"),
    /*  213 */
    STR_ADMINISTRATOR_PWD(Integer.valueOf(197), "STR_ADMINISTRATOR_PWD"),
    /*  214 */
    STR_PERMISSION_ERROR(Integer.valueOf(198), "STR_PERMISSION_ERROR"),
    /*  215 */
    STR_EXIT_INFUSION_SHUT_DOWN(Integer.valueOf(199), "STR_EXIT_INFUSION_SHUT_DOWN"),
    /*  216 */
    STR_ENTER_PWD(Integer.valueOf(200), "STR_ENTER_PWD"),
    /*  217 */
    STR_STABLE_RATE(Integer.valueOf(201), "STR_STABLE_RATE"),
    /*  218 */
    STR_TOTAL_TIME(Integer.valueOf(202), "STR_TOTAL_TIME"),
    /*  219 */
    STR_RISE_TIME(Integer.valueOf(203), "STR_RISE_TIME"),
    /*  220 */
    STR_FALL_TIME(Integer.valueOf(204), "STR_FALL_TIME"),
    /*  221 */
    STR_RISE(Integer.valueOf(205), "STR_RISE"),
    /*  222 */
    STR_STABLE(Integer.valueOf(206), "STR_STABLE"),
    /*  223 */
    STR_FALL(Integer.valueOf(207), "STR_FALL"),
    /*  224 */
    STR_INFUSION_TIME(Integer.valueOf(208), "STR_INFUSION_TIME"),
    /*  225 */
    STR_S_VOLUME(Integer.valueOf(209), "STR_S_VOLUME"),
    /*  226 */
    STR_S_INFUSION_TIME(Integer.valueOf(210), "STR_S_INFUSION_TIME"),
    /*  227 */
    STR_S_INFUSION_RATE(Integer.valueOf(211), "STR_S_INFUSION_RATE"),
    /*  228 */
    STR_ACCUMULATED_VOLUME(Integer.valueOf(212), "STR_ACCUMULATED_VOLUME"),
    /*  229 */
    STR_ACCUMULATED_TIME(Integer.valueOf(213), "STR_ACCUMULATED_TIME"),
    /*  230 */
    STR_BOULS_VOL(Integer.valueOf(214), "STR_BOULS_VOL"),
    /*  231 */
    STR_SINGLE_DOSE(Integer.valueOf(215), "STR_SINGLE_DOSE"),
    /*  232 */
    STR_BOULS_RATE(Integer.valueOf(216), "STR_BOULS_RATE"),
    /*  233 */
    STR_SINGLE_DOSE_RATE(Integer.valueOf(217), "STR_SINGLE_DOSE_RATE"),
    /*  234 */
    STR_INFUSION_INTERVAL(Integer.valueOf(218), "STR_INFUSION_INTERVAL"),
    /*  235 */
    STR_CONTINOUS_DOSE_RATE(Integer.valueOf(219), "STR_CONTINOUS_DOSE_RATE"),
    /*  236 */
    STR_LOADING_RATE(Integer.valueOf(220), "STR_LOADING_RATE"),
    /*  237 */
    STR_MAINTAIN_RATE(Integer.valueOf(221), "STR_MAINTAIN_RATE"),
    /*  238 */
    STR_LOADING_TIME(Integer.valueOf(222), "STR_LOADING_TIME"),
    /*  239 */
    STR_MAINTAIN_TIME(Integer.valueOf(223), "STR_MAINTAIN_TIME"),
    /*  240 */
    STR_MAINTAIN(Integer.valueOf(224), "STR_MAINTAIN"),
    /*  241 */
    STR_PDW_ERROR(Integer.valueOf(225), "STR_PDW_ERROR"),
    /*  242 */
    STR_NEW_PWD(Integer.valueOf(226), "STR_NEW_PWD"),
    /*  243 */
    STR_REPEAT_PWD(Integer.valueOf(227), "STR_REPEAT_PWD"),
    /*  244 */
    STR_PDW_RESET(Integer.valueOf(228), "STR_PDW_RESET"),
    /*  245 */
    STR_POWER_OFF(Integer.valueOf(229), "STR_POWER_OFF"),
    /*  246 */
    STR_CALCULATION(Integer.valueOf(230), "STR_CALCULATION"),
    /*  247 */
    STR_STANDBY(Integer.valueOf(231), "STR_STANDBY"),
    /*  248 */
    STR_CHRO_TIME_CROSS_TIP(Integer.valueOf(232), "STR_CHRO_TIME_CROSS_TIP"),
    /*  249 */
    STR_CHRONOLOGICAL_MODE_SET(Integer.valueOf(233), "STR_CHRONOLOGICAL_MODE_SET"),
    /*  250 */
    STR_WEIGHT_MODE_SET(Integer.valueOf(234), "STR_WEIGHT_MODE_SET"),
    /*  251 */
    STR_DRUG_SELECTION(Integer.valueOf(235), "STR_DRUG_SELECTION"),
    /*  252 */
    STR_BSA_FORMULA(Integer.valueOf(236), "STR_BSA_FORMULA"),
    /*  253 */
    STR_CONCENTRATION_UNIT(Integer.valueOf(237), "STR_CONCENTRATION_UNIT"),
    /*  254 */
    STR_DOSE_RATE_UNIT(Integer.valueOf(238), "STR_DOSE_RATE_UNIT"),
    /*  255 */
    STR_UNIT_M2(Integer.valueOf(239), "STR_UNIT_M2"),
    /*  256 */
    STR_UNIT_KG(Integer.valueOf(240), "STR_UNIT_KG"),
    /*  257 */
    STR_UNIT_G(Integer.valueOf(241), "STR_UNIT_G"),
    /*  258 */
    STR_UNIT_MG(Integer.valueOf(242), "STR_UNIT_MG"),
    /*  259 */
    STR_UNIT_UG(Integer.valueOf(243), "STR_UNIT_UG"),
    /*  260 */
    STR_UNIT_NG(Integer.valueOf(244), "STR_UNIT_NG"),
    /*  261 */
    STR_UNIT_KIU(Integer.valueOf(245), "STR_UNIT_KIU"),
    /*  262 */
    STR_UNIT_IU(Integer.valueOf(246), "STR_UNIT_IU"),
    /*  263 */
    STR_UNIT_MIU(Integer.valueOf(247), "STR_UNIT_MIU"),
    /*  264 */
    STR_UNIT_EU(Integer.valueOf(248), "STR_UNIT_EU"),
    /*  265 */
    STR_UNIT_MOL(Integer.valueOf(249), "STR_UNIT_MOL"),
    /*  266 */
    STR_UNIT_MMOL(Integer.valueOf(250), "STR_UNIT_MMOL"),
    /*  267 */
    STR_UNIT_KCAL(Integer.valueOf(251), "STR_UNIT_KCAL"),
    /*  268 */
    STR_UNIT_MEQ(Integer.valueOf(252), "STR_UNIT_MEQ"),
    /*  269 */
    STR_UNIT_UNIT(Integer.valueOf(253), "STR_UNIT_UNIT"),
    /*  270 */
    STR_UNIT_KUNIT(Integer.valueOf(254), "STR_UNIT_KUNIT"),
    /*  271 */
    STR_UNIT_MUNIT(Integer.valueOf(255), "STR_UNIT_MUNIT"),
    /*  272 */
    STR_DOSE_UNIT_MIN(Integer.valueOf(256), "STR_DOSE_UNIT_MIN"),
    /*  273 */
    STR_DOSE_UNIT_H(Integer.valueOf(257), "STR_DOSE_UNIT_H"),
    /*  274 */
    STR_DOSE_UNIT_24H(Integer.valueOf(258), "STR_DOSE_UNIT_24H"),
    /*  275 */
    STR_DELIVERY_HISTORY(Integer.valueOf(259), "STR_DELIVERY_HISTORY"),
    /*  276 */
    STR_PATIENT_BOLUS_GRAPH(Integer.valueOf(260), "STR_PATIENT_BOLUS_GRAPH"),
    /*  277 */
    STR_ETCO2(Integer.valueOf(261), "STR_ETCO2"),
    /*  278 */
    STR_RR(Integer.valueOf(262), "STR_RR"),
    /*  279 */
    STR_KVO_SET(Integer.valueOf(263), "STR_KVO_SET"),
    /*  280 */
    STR_PRIME_SET(Integer.valueOf(264), "STR_PRIME_SET"),
    /*  281 */
    STR_COMMON_SET(Integer.valueOf(265), "STR_COMMON_SET"),
    /*  282 */
    STR_CURRENT_AMOUNT(Integer.valueOf(266), "STR_CURRENT_AMOUNT"),
    /*  283 */
    STR_DETAILS(Integer.valueOf(267), "STR_DETAILS"),
    /*  284 */
    STR_EVENT_EXIT_STANDBY(Integer.valueOf(268), "STR_EVENT_EXIT_STANDBY"),
    /*  285 */
    STR_EVENT_NEW_PATIENT(Integer.valueOf(269), "STR_EVENT_NEW_PATIENT"),
    /*  286 */
    STR_EVENT_PCA_INFUSION_START(Integer.valueOf(270), "STR_EVENT_PCA_INFUSION_START"),
    /*  287 */
    STR_EVENT_PIEB_INFUSION_START(Integer.valueOf(271), "STR_EVENT_PIEB_INFUSION_START"),
    /*  288 */
    STR_EVENT_PCEA_INFUSION_START(Integer.valueOf(272), "STR_EVENT_PCEA_INFUSION_START"),
    /*  289 */
    STR_EVENT_PCS_INFUSION_START(Integer.valueOf(273), "STR_EVENT_PCS_INFUSION_START"),
    /*  290 */
    STR_EVENT_CHRONOLOGICAL_INFUSION_START(Integer.valueOf(274), "STR_EVENT_CHRONOLOGICAL_INFUSION_START"),
    /*  291 */
    STR_EVENT_RATE_INFUSION_START(Integer.valueOf(275), "STR_EVENT_RATE_INFUSION_START"),
    /*  292 */
    STR_EVENT_TIME_INFUSION_START(Integer.valueOf(276), "STR_EVENT_TIME_INFUSION_START"),
    /*  293 */
    STR_EVENT_WEIGHT_INFUSION_START(Integer.valueOf(277), "STR_EVENT_WEIGHT_INFUSION_START"),
    /*  294 */
    STR_EVENT_SEQUENCE_INFUSION_START(Integer.valueOf(278), "STR_EVENT_SEQUENCE_INFUSION_START"),
    /*  295 */
    STR_EVENT_LOADING_DOSE_INFUSION_START(Integer.valueOf(279), "STR_EVENT_LOADING_DOSE_INFUSION_START"),
    /*  296 */
    STR_EVENT_INTERMITTENT_INFUSION_START(Integer.valueOf(280), "STR_EVENT_INTERMITTENT_INFUSION_START"),
    /*  297 */
    STR_EVENT_TRAPEZIA_INFUSION_START(Integer.valueOf(281), "STR_EVENT_TRAPEZIA_INFUSION_START"),
    /*  298 */
    STR_EVENT_KVO_STOP(Integer.valueOf(282), "STR_EVENT_KVO_STOP"),
    /*  299 */
    STR_EVENT_PASSWORD_CHANGE(Integer.valueOf(283), "STR_EVENT_PASSWORD_CHANGE"),
    /*  300 */
    STR_EVENT_VALID_COMPRESSION(Integer.valueOf(284), "STR_EVENT_VALID_COMPRESSION"),
    /*  301 */
    STR_EVENT_INVALID_COMPRESSION(Integer.valueOf(285), "STR_EVENT_INVALID_COMPRESSION"),
    /*  302 */
    STR_EVENT_DEVICE_SERIAL_NUMBER(Integer.valueOf(286), "STR_EVENT_DEVICE_SERIAL_NUMBER"),
    /*  303 */
    STR_SOFTWARE_RELEASE_VERSION(Integer.valueOf(287), "STR_SOFTWARE_RELEASE_VERSION"),
    /*  304 */
    STR_SAVE_PRESET_TREATMENT_PLAN(Integer.valueOf(288), "STR_SAVE_PRESET_TREATMENT_PLAN"),
    /*  305 */
    STR_NAME_TREATMENT_PLAN(Integer.valueOf(289), "STR_NAME_TREATMENT_PLAN"),
    /*  306 */
    STR_OLDEST_TREATMENT_PLAN_DELETE(Integer.valueOf(290), "STR_OLDEST_TREATMENT_PLAN_DELETE"),
    /*  307 */
    STR_TREATMENT_PLAN_SAVED_SUCCESS(Integer.valueOf(291), "STR_TREATMENT_PLAN_SAVED_SUCCESS"),
    /*  308 */
    STR_PASSWORD(Integer.valueOf(292), "STR_PASSWORD"),
    /*  309 */
    STR_PWD_INCONSISTENT_FAILED(Integer.valueOf(293), "STR_PWD_INCONSISTENT_FAILED"),
    /*  310 */
    STR_PHASE_N_TIME(Integer.valueOf(294), "STR_PHASE_N_TIME"),
    /*  311 */
    STR_PHASE_N_RATE(Integer.valueOf(295), "STR_PHASE_N_RATE"),
    /*  312 */
    STR_PHASE_N(Integer.valueOf(296), "STR_PHASE_N"),
    /*  313 */
    STR_PRIME_RATE(Integer.valueOf(297), "STR_PRIME_RATE"),
    /*  314 */
    STR_SINGLE_PRIME_VOL(Integer.valueOf(298), "STR_SINGLE_PRIME_VOL"),
    /*  315 */
    STR_PWD_DIGIT_ERROR(Integer.valueOf(299), "STR_PWD_DIGIT_ERROR"),
    /*  316 */
    STR_FACTORY_CALIBRATION(Integer.valueOf(300), "STR_FACTORY_CALIBRATION"),
    /*  317 */
    STR_EVENT_LOG(Integer.valueOf(301), "STR_EVENT_LOG"),
    /*  318 */
    STR_EVENT_ERR_99(Integer.valueOf(302), "STR_EVENT_ERR_99"),
    /*  319 */
    STR_EVENT_ERR_100(Integer.valueOf(303), "STR_EVENT_ERR_100"),
    /*  320 */
    STR_EVENT_ERR_101(Integer.valueOf(304), "STR_EVENT_ERR_101"),
    /*  321 */
    STR_EVENT_ERR_103(Integer.valueOf(305), "STR_EVENT_ERR_103"),
    /*  322 */
    STR_EVENT_ERR_200(Integer.valueOf(306), "STR_EVENT_ERR_200"),
    /*  323 */
    STR_EVENT_ERR_201(Integer.valueOf(307), "STR_EVENT_ERR_201"),
    /*  324 */
    STR_EVENT_ERR_202(Integer.valueOf(308), "STR_EVENT_ERR_202"),
    /*  325 */
    STR_EVENT_ERR_203(Integer.valueOf(309), "STR_EVENT_ERR_203"),
    /*  326 */
    STR_EVENT_ERR_204(Integer.valueOf(310), "STR_EVENT_ERR_204"),
    /*  327 */
    STR_EVENT_ERR_205(Integer.valueOf(311), "STR_EVENT_ERR_205"),
    /*  328 */
    STR_EVENT_ERR_208(Integer.valueOf(312), "STR_EVENT_ERR_208"),
    /*  329 */
    STR_EVENT_ERR_209(Integer.valueOf(313), "STR_EVENT_ERR_209"),
    /*  330 */
    STR_EVENT_ERR_210(Integer.valueOf(314), "STR_EVENT_ERR_210"),
    /*  331 */
    STR_EVENT_ERR_211(Integer.valueOf(315), "STR_EVENT_ERR_211"),
    /*  332 */
    STR_EVENT_ERR_212(Integer.valueOf(316), "STR_EVENT_ERR_212"),
    /*  333 */
    STR_EVENT_ERR_300(Integer.valueOf(317), "STR_EVENT_ERR_300"),
    /*  334 */
    STR_EVENT_ERR_303(Integer.valueOf(318), "STR_EVENT_ERR_303"),
    /*  335 */
    STR_EVENT_ERR_304(Integer.valueOf(319), "STR_EVENT_ERR_304"),
    /*  336 */
    STR_EVENT_ERR_305(Integer.valueOf(320), "STR_EVENT_ERR_305"),
    /*  337 */
    STR_EVENT_ERR_400(Integer.valueOf(321), "STR_EVENT_ERR_400"),
    /*  338 */
    STR_EVENT_ERR_401(Integer.valueOf(322), "STR_EVENT_ERR_401"),
    /*  339 */
    STR_EVENT_ERR_403(Integer.valueOf(323), "STR_EVENT_ERR_403"),
    /*  340 */
    STR_EVENT_ERR_407(Integer.valueOf(324), "STR_EVENT_ERR_407"),
    /*  341 */
    STR_EVENT_POWER_ON(Integer.valueOf(325), "STR_EVENT_POWER_ON"),
    /*  342 */
    STR_LANGUAGE(Integer.valueOf(326), "STR_LANGUAGE"),
    /*  343 */
    STR_INFUSION_PAUSE(Integer.valueOf(327), "STR_INFUSION_PAUSE"),
    /*  344 */
    STR_SET(Integer.valueOf(328), "STR_SET"),
    /*  345 */
    STR_NO_LAST_INFUSION(Integer.valueOf(329), "STR_NO_LAST_INFUSION"),
    /*  346 */
    STR_UNIT_MONITOR(Integer.valueOf(330), "STR_UNIT_MONITOR"),
    /*  347 */
    STR_BPM(Integer.valueOf(331), "STR_BPM"),
    /*  348 */
    STR_VITAL_SIGN(Integer.valueOf(332), "STR_VITAL_SIGN"),
    /*  349 */
    STR_RPM(Integer.valueOf(333), "STR_RPM"),
    /*  350 */
    STR_WLAN(Integer.valueOf(334), "STR_WLAN"),
    /*  351 */
    STR_NBIOT(Integer.valueOf(335), "STR_NBIOT"),
    /*  352 */
    STR_WLAN_SET(Integer.valueOf(336), "STR_WLAN_SET"),
    /*  353 */
    STR_WIFI_NAME(Integer.valueOf(337), "STR_WIFI_NAME"),
    /*  354 */
    STR_DHCP(Integer.valueOf(338), "STR_DHCP"),
    /*  355 */
    STR_IP(Integer.valueOf(339), "STR_IP"),
    /*  356 */
    STR_SUBNET_MASK(Integer.valueOf(340), "STR_SUBNET_MASK"),
    /*  357 */
    STR_DEFAULT_GATEWAY(Integer.valueOf(341), "STR_DEFAULT_GATEWAY"),
    /*  358 */
    STR_CENTRAL_STATION_SERVER_IP(Integer.valueOf(342), "STR_CENTRAL_STATION_SERVER_IP"),
    /*  359 */
    STR_SERVER_PORT(Integer.valueOf(343), "STR_SERVER_PORT"),
    /*  360 */
    STR_BLUETOOTH_SET(Integer.valueOf(344), "STR_BLUETOOTH_SET"),
    /*  361 */
    STR_CONNECT(Integer.valueOf(345), "STR_CONNECT"),
    /*  362 */
    STR_CONNECTED(Integer.valueOf(346), "STR_CONNECTED"),
    /*  363 */
    STR_REBOOT_OR_NOT(Integer.valueOf(347), "STR_REBOOT_OR_NOT"),
    /*  364 */
    STR_INFUSION_EXIT(Integer.valueOf(348), "STR_INFUSION_EXIT"),
    /*  365 */
    STR_INFUSION_RESUME(Integer.valueOf(349), "STR_INFUSION_RESUME"),
    /*  366 */
    STR_BLUETOOTH(Integer.valueOf(350), "STR_BLUETOOTH"),
    /*  367 */
    STR_AVAILABLE_BLUETOOTH(Integer.valueOf(351), "STR_AVAILABLE_BLUETOOTH"),
    /*  368 */
    STR_EVENT_PERMISSION_ERROR(Integer.valueOf(352), "STR_EVENT_PERMISSION_ERROR"),
    /*  369 */
    STR_UNIT_UL(Integer.valueOf(353), "STR_UNIT_UL"),
    /*  370 */
    STR_UNIT_UL_15MIN(Integer.valueOf(354), "STR_UNIT_UL_15MIN"),
    /*  371 */
    STR_COMMUNICATION_SET(Integer.valueOf(355), "STR_COMMUNICATION_SET"),
    /*  372 */
    STR_LONGITUDE(Integer.valueOf(356), "STR_LONGITUDE"),
    /*  373 */
    STR_LATITUDE(Integer.valueOf(357), "STR_LATITUDE"),
    /*  374 */
    STR_COORDINATE(Integer.valueOf(358), "STR_COORDINATE"),
    /*  375 */
    STR_COMPLETET_VERSION(Integer.valueOf(359), "STR_COMPLETET_VERSION"),
    /*  376 */
    STR_SCREEN_CALIBRATION(Integer.valueOf(360), "STR_SCREEN_CALIBRATION"),
    /*  377 */
    STR_TOUCH_TOP_LEFT_CORNER(Integer.valueOf(361), "STR_TOUCH_TOP_LEFT_CORNER"),
    /*  378 */
    STR_CALIBRATION_SUCCESS(Integer.valueOf(362), "STR_CALIBRATION_SUCCESS"),
    /*  379 */
    STR_OPTION_CALIBRATION_FAIL(Integer.valueOf(363), "STR_OPTION_CALIBRATION_FAIL"),
    /*  380 */
    STR_CASSETTE_ATTACHED(Integer.valueOf(364), "STR_CASSETTE_ATTACHED"),
    /*  381 */
    STR_CASSETTE_LOCKED(Integer.valueOf(365), "STR_CASSETTE_LOCKED"),
    /*  382 */
    STR_STOP_INFUSION(Integer.valueOf(366), "STR_STOP_INFUSION"),
    /*  383 */
    STR_CONTINUE_INFUSION(Integer.valueOf(367), "STR_CONTINUE_INFUSION"),
    /*  384 */
    STR_ALARM_ADVANCE(Integer.valueOf(368), "STR_ALARM_ADVANCE"),
    /*  385 */
    STR_BOULS_FAILED(Integer.valueOf(369), "STR_BOULS_FAILED"),
    /*  386 */
    STR_ANALGESIA_EVALUATION(Integer.valueOf(370), "STR_ANALGESIA_EVALUATION"),
    /*  387 */
    STR_PAIN_SCORE_REST(Integer.valueOf(371), "STR_PAIN_SCORE_REST"),
    /*  388 */
    STR_PAIN_SCORE_ACTIVITY(Integer.valueOf(372), "STR_PAIN_SCORE_ACTIVITY"),
    /*  389 */
    STR_ADVERSE_REACTIONS(Integer.valueOf(373), "STR_ADVERSE_REACTIONS"),
    /*  390 */
    STR_NAUSEA(Integer.valueOf(374), "STR_NAUSEA"),
    /*  391 */
    STR_SKIN_ITCH(Integer.valueOf(375), "STR_SKIN_ITCH"),
    /*  392 */
    STR_HYPOTENSION(Integer.valueOf(376), "STR_HYPOTENSION"),
    /*  393 */
    STR_FEVER(Integer.valueOf(377), "STR_FEVER"),
    /*  394 */
    STR_LIMB_WEAKNESS(Integer.valueOf(378), "STR_LIMB_WEAKNESS"),
    /*  395 */
    STR_ABDOMINAL_DISTENSION(Integer.valueOf(379), "STR_ABDOMINAL_DISTENSION"),
    /*  396 */
    STR_HYPERSOMNIA(Integer.valueOf(380), "STR_HYPERSOMNIA"),
    /*  397 */
    STR_VOMIT(Integer.valueOf(381), "STR_VOMIT"),
    /*  398 */
    STR_ADVERSE_REACTIONS_COMPLETED(Integer.valueOf(382), "STR_ADVERSE_REACTIONS_COMPLETED"),
    /*  399 */
    STR_CONC_CONFIG(Integer.valueOf(383), "STR_CONC_CONFIG"),
    /*  400 */
    STR_AMOUNT_VOLUME(Integer.valueOf(384), "STR_AMOUNT_VOLUME"),
    /*  401 */
    STR_ONLY_VTBI_FAILED(Integer.valueOf(385), "STR_ONLY_VTBI_FAILED"),
    /*  402 */
    STR_DOSE_METHOD(Integer.valueOf(386), "STR_DOSE_METHOD"),
    /*  403 */
    STR_DOSE_CALCULATION(Integer.valueOf(387), "STR_DOSE_CALCULATION"),
    /*  404 */
    STR_ONLY_CONC(Integer.valueOf(388), "STR_ONLY_CONC"),
    /*  405 */
    STR_CONC_WEIGHT(Integer.valueOf(389), "STR_CONC_WEIGHT"),
    /*  406 */
    STR_CONC_BSA(Integer.valueOf(390), "STR_CONC_BSA"),
    /*  407 */
    STR_PHASE_SETTINGS(Integer.valueOf(391), "STR_PHASE_SETTINGS"),
    /*  408 */
    STR_BSA_CONFIG(Integer.valueOf(392), "STR_BSA_CONFIG"),
    /*  409 */
    STR_HEIGHT_WEIGHT(Integer.valueOf(393), "STR_HEIGHT_WEIGHT"),
    /*  410 */
    STR_DEMAND_DOSE(Integer.valueOf(394), "STR_DEMAND_DOSE"),
    /*  411 */
    STR_DOSE_LMT(Integer.valueOf(395), "STR_DOSE_LMT"),
    /*  412 */
    STR_SEQUENCE_SET(Integer.valueOf(396), "STR_SEQUENCE_SET"),
    /*  413 */
    STR_TIP_GIVE_SCORE(Integer.valueOf(397), "STR_TIP_GIVE_SCORE"),
    /*  414 */
    STR_DOSE_LIMIT(Integer.valueOf(398), "STR_DOSE_LIMIT"),
    /*  415 */
    STR_DOSE_LIMIT_HOUR(Integer.valueOf(399), "STR_DOSE_LIMIT_HOUR"),
    /*  416 */
    STR_MAINTAIN_VOL(Integer.valueOf(400), "STR_MAINTAIN_VOL"),
    /*  417 */
    STR_S_TIME(Integer.valueOf(401), "STR_S_TIME"),
    /*  418 */
    STR_RISE_VOL(Integer.valueOf(402), "STR_RISE_VOL"),
    /*  419 */
    STR_STEADY_VOL(Integer.valueOf(403), "STR_STEADY_VOL"),
    /*  420 */
    STR_STEADY_TIME(Integer.valueOf(404), "STR_STEADY_TIME"),
    /*  421 */
    STR_FALL_VOL(Integer.valueOf(405), "STR_FALL_VOL"),
    /*  422 */
    STR_DEL_PHASE(Integer.valueOf(406), "STR_DEL_PHASE"),
    /*  423 */
    STR_DEL_SEQUENCE(Integer.valueOf(407), "STR_DEL_SEQUENCE"),
    /*  424 */
    STR_INTERMITTENT_MODE_SET(Integer.valueOf(408), "STR_INTERMITTENT_MODE_SET"),
    /*  425 */
    STR_AVAILABLE_WLAN(Integer.valueOf(409), "STR_AVAILABLE_WLAN"),
    /*  426 */
    STR_ADD_NETWORK(Integer.valueOf(410), "STR_ADD_NETWORK"),
    /*  427 */
    STR_CONNECTING(Integer.valueOf(411), "STR_CONNECTING"),
    /*  428 */
    STR_CHRON_MODE(Integer.valueOf(412), "STR_CHRON_MODE"),
    /*  429 */
    STR_L_DOSE_MODE(Integer.valueOf(413), "STR_L_DOSE_MODE"),
    /*  430 */
    STR_TIP_CHRON_START_INFUSION(Integer.valueOf(414), "STR_TIP_CHRON_START_INFUSION"),
    /*  431 */
    STR_CHRON_H(Integer.valueOf(415), "STR_CHRON_H"),
    /*  432 */
    STR_CHRON_MIN(Integer.valueOf(416), "STR_CHRON_MIN"),
    /*  433 */
    STR_BUTTON_START(Integer.valueOf(417), "STR_BUTTON_START"),
    /*  434 */
    STR_BUTTON_PUASE(Integer.valueOf(418), "STR_BUTTON_PUASE"),
    /*  435 */
    STR_STATE_COMPLETE(Integer.valueOf(419), "STR_STATE_COMPLETE"),
    /*  436 */
    STR_CONNECTION_FAILED(Integer.valueOf(420), "STR_CONNECTION_FAILED"),
    /*  437 */
    STR_REFRESH(Integer.valueOf(421), "STR_REFRESH"),
    /*  438 */
    STR_PUMP_NO(Integer.valueOf(422), "STR_PUMP_NO"),
    /*  439 */
    STR_LAST_NAME(Integer.valueOf(423), "STR_LAST_NAME"),
    /*  440 */
    STR_FIRST_NAME(Integer.valueOf(424), "STR_FIRST_NAME"),
    /*  441 */
    STR_PID(Integer.valueOf(425), "STR_PID"),
    /*  442 */
    STR_DEPARTMENT(Integer.valueOf(426), "STR_DEPARTMENT"),
    /*  443 */
    STR_WARD(Integer.valueOf(427), "STR_WARD"),
    /*  444 */
    STR_BED_NO(Integer.valueOf(428), "STR_BED_NO"),
    /*  445 */
    STR_PATIENT_DISPLAY(Integer.valueOf(429), "STR_PATIENT_DISPLAY"),
    /*  446 */
    STR_NAME(Integer.valueOf(430), "STR_NAME"),
    /*  447 */
    STR_ADMIT_PATIENT(Integer.valueOf(431), "STR_ADMIT_PATIENT"),
    /*  448 */
    STR_TIP_ADMIT_PATIENT(Integer.valueOf(432), "STR_TIP_ADMIT_PATIENT"),
    /*  449 */
    STR_PATIENT_DATA(Integer.valueOf(433), "STR_PATIENT_DATA"),
    /*  450 */
    STR_CMS_NOT_CONNECTED_CHECK(Integer.valueOf(434), "STR_CMS_NOT_CONNECTED_CHECK"),
    /*  451 */
    STR_TIP_PUT_PATIENT_BARCODE(Integer.valueOf(435), "STR_TIP_PUT_PATIENT_BARCODE"),
    /*  452 */
    STR_SCAN_FAILED(Integer.valueOf(436), "STR_SCAN_FAILED"),
    /*  453 */
    STR_TIP_WAIT_TO_DOWNLOAD(Integer.valueOf(437), "STR_TIP_WAIT_TO_DOWNLOAD"),
    /*  454 */
    STR_FAILED_TO_DOWNLOAD(Integer.valueOf(438), "STR_FAILED_TO_DOWNLOAD"),
    /*  455 */
    STR_DISCONNECT(Integer.valueOf(439), "STR_DISCONNECT"),
    /*  456 */
    STR_PATIENT_MANAGEMENT(Integer.valueOf(440), "STR_PATIENT_MANAGEMENT"),
    /*  457 */
    STR_RX_INFO(Integer.valueOf(441), "STR_RX_INFO"),
    /*  458 */
    STR_RX_PRESCRIPTION(Integer.valueOf(442), "STR_RX_PRESCRIPTION"),
    /*  459 */
    STR_NOT_BE_NULL(Integer.valueOf(443), "STR_NOT_BE_NULL"),
    /*  460 */
    STR_EDIT_PARAM(Integer.valueOf(444), "STR_EDIT_PARAM"),
    /*  461 */
    STR_CLEAR_VI(Integer.valueOf(445), "STR_CLEAR_VI"),
    /*  462 */
    STR_TIP_CLEAR_VI(Integer.valueOf(446), "STR_TIP_CLEAR_VI"),
    /*  463 */
    STR_QUICK_SET(Integer.valueOf(447), "STR_QUICK_SET"),
    /*  464 */
    STR_TRAPEZIA_MODE_SET(Integer.valueOf(448), "STR_TRAPEZIA_MODE_SET"),
    /*  465 */
    STR_RESYCLE_PUMP(Integer.valueOf(449), "STR_RESYCLE_PUMP"),
    /*  466 */
    STR_TIP_NEW_PATIENT_ADMIT(Integer.valueOf(450), "STR_TIP_NEW_PATIENT_ADMIT"),
    /*  467 */
    STR_TIP_EDIT_PARAM(Integer.valueOf(451), "STR_TIP_EDIT_PARAM"),
    /*  468 */
    STR_INSUFFICIENT_ANALGESIA_TIMES(Integer.valueOf(452), "STR_INSUFFICIENT_ANALGESIA_TIMES"),
    /*  469 */
    STR_INSUFFICIENT_ANALGESIA(Integer.valueOf(453), "STR_INSUFFICIENT_ANALGESIA"),
    /*  470 */
    STR_TIP_INSUFFICIENT_ANALGESIA(Integer.valueOf(454), "STR_TIP_INSUFFICIENT_ANALGESIA"),
    /*  471 */
    STR_AUTO_RESTART(Integer.valueOf(455), "STR_AUTO_RESTART"),
    /*  472 */
    STR_MACHINE_CONFIG(Integer.valueOf(456), "STR_MACHINE_CONFIG"),
    /*  473 */
    STR_MACHINE_P2(Integer.valueOf(457), "STR_MACHINE_P2"),
    /*  474 */
    STR_MACHINE_P3(Integer.valueOf(458), "STR_MACHINE_P3"),
    /*  475 */
    STR_MACHINE_P5(Integer.valueOf(459), "STR_MACHINE_P5"),
    /*  476 */
    STR_MACHINE_P6(Integer.valueOf(460), "STR_MACHINE_P6"),
    /*  477 */
    STR_MACHINE_P8(Integer.valueOf(461), "STR_MACHINE_P8"),
    /*  478 */
    STR_MACHINE_P9(Integer.valueOf(462), "STR_MACHINE_P9"),
    /*  479 */
    STR_MODULE_SCANNER(Integer.valueOf(463), "STR_MODULE_SCANNER"),
    /*  480 */
    STR_UPSTREAM_SENSOR(Integer.valueOf(464), "STR_UPSTREAM_SENSOR"),
    /*  481 */
    STR_FIXED_MODEL(Integer.valueOf(465), "STR_FIXED_MODEL"),
    /*  482 */
    STR_ON(Integer.valueOf(466), "STR_ON"),
    /*  483 */
    STR_MODEL_CHOICE(Integer.valueOf(467), "STR_MODEL_CHOICE"),
    /*  484 */
    STR_TIP_FIXED_MODEL(Integer.valueOf(468), "STR_TIP_FIXED_MODEL"),
    /*  485 */
    STR_AUTO_SLEEP(Integer.valueOf(469), "STR_AUTO_SLEEP"),
    /*  486 */
    STR_AUTO_SLEEP_IN_INFUSION(Integer.valueOf(470), "STR_AUTO_SLEEP_IN_INFUSION"),
    /*  487 */
    STR_AUTO_SLEEP_NO_INFUSION(Integer.valueOf(471), "STR_AUTO_SLEEP_NO_INFUSION"),
    /*  488 */
    STR_AUTO_SLEEP_OFF(Integer.valueOf(472), "STR_AUTO_SLEEP_OFF"),
    /*  489 */
    STR_PUMP_NO_REPAET(Integer.valueOf(473), "STR_PUMP_NO_REPAET"),
    /*  490 */
    STR_PID_REPEAT(Integer.valueOf(474), "STR_PID_REPEAT"),
    /*  491 */
    STR_PUMP_REMOVED(Integer.valueOf(475), "STR_PUMP_REMOVED"),
    /*  492 */
    STR_LAST(Integer.valueOf(476), "STR_LAST"),
    /*  493 */
    STR_ADMIT_TIME(Integer.valueOf(477), "STR_ADMIT_TIME"),
    /*  494 */
    STR_THIS_INFUSION(Integer.valueOf(478), "STR_THIS_INFUSION"),
    /*  495 */
    STR_VI(Integer.valueOf(479), "STR_VI"),
    /*  496 */
    STR_INFUSION_DETAILS(Integer.valueOf(480), "STR_INFUSION_DETAILS"),
    /*  497 */
    STR_PIEB_DOSE(Integer.valueOf(481), "STR_PIEB_DOSE"),
    /*  498 */
    STR_TOTAL_DEMAND_DOSE(Integer.valueOf(482), "STR_TOTAL_DEMAND_DOSE"),
    /*  499 */
    STR_CONTINUOUS_DOSE(Integer.valueOf(483), "STR_CONTINUOUS_DOSE"),
    /*  500 */
    STR_CLINICIAN_BOLUS_DOSE(Integer.valueOf(484), "STR_CLINICIAN_BOLUS_DOSE"),
    /*  501 */
    STR_PAIN_SCORE(Integer.valueOf(485), "STR_PAIN_SCORE"),
    /*  502 */
    STR_SCORE_AT_REST(Integer.valueOf(486), "STR_SCORE_AT_REST"),
    /*  503 */
    STR_SCORE_UNDER_ACTIVITY(Integer.valueOf(487), "STR_SCORE_UNDER_ACTIVITY"),
    /*  504 */
    STR_SCORE_TIME(Integer.valueOf(488), "STR_SCORE_TIME"),
    /*  505 */
    STR_TIME_RANGE(Integer.valueOf(489), "STR_TIME_RANGE"),
    /*  506 */
    STR_EMPTY_SN(Integer.valueOf(490), "STR_EMPTY_SN"),
    /*  507 */
    STR_HELP_ALARM_BAT_LOW_STD(Integer.valueOf(491), "STR_HELP_ALARM_BAT_LOW_STD"),
    /*  508 */
    STR_NO_LAST_INFUSION_PATIENT(Integer.valueOf(492), "STR_NO_LAST_INFUSION_PATIENT"),
    /*  509 */
    STR_FIGURE_INVALID(Integer.valueOf(493), "STR_FIGURE_INVALID"),
    /*  510 */
    STR_FIGURE_VALID(Integer.valueOf(494), "STR_FIGURE_VALID"),
    /*  511 */
    STR_PIEB_TIMES(Integer.valueOf(495), "STR_PIEB_TIMES"),
    /*  512 */
    STR_TIME_FROM(Integer.valueOf(496), "STR_TIME_FROM"),
    /*  513 */
    STR_TIME_TO(Integer.valueOf(497), "STR_TIME_TO"),
    /*  514 */
    STR_INFUSION_POWER_OFF(Integer.valueOf(498), "STR_INFUSION_POWER_OFF"),
    /*  515 */
    STR_START_PRESET_INFUSION(Integer.valueOf(499), "STR_START_PRESET_INFUSION"),
    /*  516 */
    STR_AC_POWER_SUPPLY(Integer.valueOf(500), "STR_AC_POWER_SUPPLY"),
    /*  517 */
    STR_BATTERY_SUPPLY(Integer.valueOf(501), "STR_BATTERY_SUPPLY"),
    /*  518 */
    STR_ACCEPT_FROM(Integer.valueOf(502), "STR_ACCEPT_FROM"),
    /*  519 */
    STR_ACCEPT_PUMP(Integer.valueOf(503), "STR_ACCEPT_PUMP"),
    /*  520 */
    STR_ACCEPT_CMS(Integer.valueOf(504), "STR_ACCEPT_CMS"),
    /*  521 */
    STR_CHANGE_PATIENT_DATA(Integer.valueOf(505), "STR_CHANGE_PATIENT_DATA"),
    /*  522 */
    STR_CHANGE_FROM(Integer.valueOf(506), "STR_CHANGE_FROM"),
    /*  523 */
    STR_CHANGE_PUMP(Integer.valueOf(507), "STR_CHANGE_PUMP"),
    /*  524 */
    STR_CHANGE_CMS(Integer.valueOf(508), "STR_CHANGE_CMS"),
    /*  525 */
    STR_RATE_MODE_IN_EFFECT(Integer.valueOf(509), "STR_RATE_MODE_IN_EFFECT"),
    /*  526 */
    STR_TIME_MODE_IN_EFFECT(Integer.valueOf(510), "STR_TIME_MODE_IN_EFFECT"),
    /*  527 */
    STR_WEIGHT_MODE_IN_EFFECT(Integer.valueOf(511), "STR_WEIGHT_MODE_IN_EFFECT"),
    /*  528 */
    STR_SEQUENCE_MODE_IN_EFFECT(Integer.valueOf(512), "STR_SEQUENCE_MODE_IN_EFFECT"),
    /*  529 */
    STR_L_DOSE_MODE_IN_EFFECT(Integer.valueOf(513), "STR_L_DOSE_MODE_IN_EFFECT"),
    /*  530 */
    STR_INTERMITTENT_MODE_IN_EFFECT(Integer.valueOf(514), "STR_INTERMITTENT_MODE_IN_EFFECT"),
    /*  531 */
    STR_TRAPEZIA_MODE_IN_EFFECT(Integer.valueOf(515), "STR_TRAPEZIA_MODE_IN_EFFECT"),
    /*  532 */
    STR_CHRON_MODE_IN_EFFECT(Integer.valueOf(516), "STR_CHRON_MODE_IN_EFFECT"),
    /*  533 */
    STR_PCA_MODE_IN_EFFECT(Integer.valueOf(517), "STR_PCA_MODE_IN_EFFECT"),
    /*  534 */
    STR_PCEA_MODE_IN_EFFECT(Integer.valueOf(518), "STR_PCEA_MODE_IN_EFFECT"),
    /*  535 */
    STR_PCS_MODE_IN_EFFECT(Integer.valueOf(519), "STR_PCS_MODE_IN_EFFECT"),
    /*  536 */
    STR_ACCEPT_RX(Integer.valueOf(520), "STR_ACCEPT_RX"),
    /*  537 */
    STR_CANCEL_RX(Integer.valueOf(521), "STR_CANCEL_RX"),
    /*  538 */
    STR_DRUG(Integer.valueOf(522), "STR_DRUG"),
    /*  539 */
    STR_SWITCH_ON(Integer.valueOf(523), "STR_SWITCH_ON"),
    /*  540 */
    STR_SWITCH_OFF(Integer.valueOf(524), "STR_SWITCH_OFF"),
    /*  541 */
    STR_STAGE(Integer.valueOf(525), "STR_STAGE"),
    /*  542 */
    STR_ENTER_INFUSION_STAGE(Integer.valueOf(526), "STR_ENTER_INFUSION_STAGE"),
    /*  543 */
    STR_CANCEL_INFUSION(Integer.valueOf(527), "STR_CANCEL_INFUSION"),
    /*  544 */
    STR_AUTO_PRIME_START(Integer.valueOf(528), "STR_AUTO_PRIME_START"),
    /*  545 */
    STR_AUTO_PRIME_STOP(Integer.valueOf(529), "STR_AUTO_PRIME_STOP"),
    /*  546 */
    STR_MANUAL_C_BOLUS_START(Integer.valueOf(530), "STR_MANUAL_C_BOLUS_START"),
    /*  547 */
    STR_MANUAL_C_BOLUS_STOP(Integer.valueOf(531), "STR_MANUAL_C_BOLUS_STOP"),
    /*  548 */
    STR_SEMI_C_BOLUS_START(Integer.valueOf(532), "STR_SEMI_C_BOLUS_START"),
    /*  549 */
    STR_SEMI_C_BOLUS_STOP(Integer.valueOf(533), "STR_SEMI_C_BOLUS_STOP"),
    /*  550 */
    STR_AUTO_C_BOLUS_START(Integer.valueOf(534), "STR_AUTO_C_BOLUS_START"),
    /*  551 */
    STR_AUTO_C_BOLUS_STOP(Integer.valueOf(535), "STR_AUTO_C_BOLUS_STOP"),
    /*  552 */
    STR_SCORE(Integer.valueOf(536), "STR_SCORE"),
    /*  553 */
    STR_TITRATION_SETTING(Integer.valueOf(537), "STR_TITRATION_SETTING"),
    /*  554 */
    STR_BLUETOOTH_CONNECT(Integer.valueOf(538), "STR_BLUETOOTH_CONNECT"),
    /*  555 */
    STR_CMS_CONNECT(Integer.valueOf(539), "STR_CMS_CONNECT"),
    /*  556 */
    STR_BEFORE_CHANGE(Integer.valueOf(540), "STR_BEFORE_CHANGE"),
    /*  557 */
    STR_AFTER_CHANGE(Integer.valueOf(541), "STR_AFTER_CHANGE"),
    /*  558 */
    STR_PASSWORD_TYPE(Integer.valueOf(542), "STR_PASSWORD_TYPE"),
    /*  559 */
    STR_FACTORY_RESETED(Integer.valueOf(543), "STR_FACTORY_RESETED"),
    /*  560 */
    STR_EVENT_LOG_CLEARED(Integer.valueOf(544), "STR_EVENT_LOG_CLEARED"),
    /*  561 */
    STR_CLOCK_SYNCH(Integer.valueOf(545), "STR_CLOCK_SYNCH"),
    /*  562 */
    STR_REBOOT_INF_RESUME(Integer.valueOf(546), "STR_REBOOT_INF_RESUME"),
    /*  563 */
    STR_MODIFY_SYSTEM_SETTING(Integer.valueOf(547), "STR_MODIFY_SYSTEM_SETTING"),
    /*  564 */
    STR_MODIFY_INFUSION_SETTING(Integer.valueOf(548), "STR_MODIFY_INFUSION_SETTING"),
    /*  565 */
    STR_MANUAL_BOLUS_LIMIT_REACHED(Integer.valueOf(549), "STR_MANUAL_BOLUS_LIMIT_REACHED"),
    /*  566 */
    STR_SCREEN_CALIBRATION_SUCCESS(Integer.valueOf(550), "STR_SCREEN_CALIBRATION_SUCCESS"),
    /*  567 */
    STR_SCREEN_CALIBRATION_FAIL(Integer.valueOf(551), "STR_SCREEN_CALIBRATION_FAIL"),
    /*  568 */
    STR_SERVICE_DUE(Integer.valueOf(552), "STR_SERVICE_DUE"),
    /*  569 */
    STR_SERVICE_DAY(Integer.valueOf(553), "STR_SERVICE_DAY"),
    /*  570 */
    STR_FAULT_SITE(Integer.valueOf(554), "STR_FAULT_SITE"),
    /*  571 */
    STR_POWER_BUTTON(Integer.valueOf(555), "STR_POWER_BUTTON"),
    /*  572 */
    STR_PCADOSE(Integer.valueOf(556), "STR_PCADOSE"),
    /*  573 */
    STR_ACTUAL_STANDBY(Integer.valueOf(557), "STR_ACTUAL_STANDBY"),
    /*  574 */
    STR_CLEAR_ALARM(Integer.valueOf(558), "STR_CLEAR_ALARM"),
    /*  575 */
    STR_ALARM_TIME(Integer.valueOf(559), "STR_ALARM_TIME"),
    /*  576 */
    STR_CLEAR_TIME(Integer.valueOf(560), "STR_CLEAR_TIME"),
    /*  577 */
    STR_CLEAR_REASON(Integer.valueOf(561), "STR_CLEAR_REASON"),
    /*  578 */
    STR_PRIME_TO_CLEAR(Integer.valueOf(562), "STR_PRIME_TO_CLEAR"),
    /*  579 */
    STR_NOT_REACHED_ALARM_STANDARD(Integer.valueOf(563), "STR_NOT_REACHED_ALARM_STANDARD"),
    /*  580 */
    STR_DATA_ID(Integer.valueOf(564), "STR_DATA_ID"),
    /*  581 */
    STR_INITIAL_ADDRESS(Integer.valueOf(565), "STR_INITIAL_ADDRESS"),
    /*  582 */
    STR_EXPECTED_LENGTH(Integer.valueOf(566), "STR_EXPECTED_LENGTH"),
    /*  583 */
    STR_ACTUAL_LENGTH(Integer.valueOf(567), "STR_ACTUAL_LENGTH"),
    /*  584 */
    STR_CURRENT_AD(Integer.valueOf(568), "STR_CURRENT_AD"),
    /*  585 */
    STR_TEST_DURATION(Integer.valueOf(569), "STR_TEST_DURATION"),
    /*  586 */
    STR_AD_VALUE(Integer.valueOf(570), "STR_AD_VALUE"),
    /*  587 */
    STR_ROTATION_TIME(Integer.valueOf(571), "STR_ROTATION_TIME"),
    /*  588 */
    STR_MOTOR_ROTATION_INTERVAL(Integer.valueOf(572), "STR_MOTOR_ROTATION_INTERVAL"),
    /*  589 */
    STR_INTERVAL_TIME(Integer.valueOf(573), "STR_INTERVAL_TIME"),
    /*  590 */
    STR_VOLTAGE_AD(Integer.valueOf(574), "STR_VOLTAGE_AD"),
    /*  591 */
    STR_INFUSION_PARAM(Integer.valueOf(575), "STR_INFUSION_PARAM"),
    /*  592 */
    STR_CHANGE_PARAM(Integer.valueOf(576), "STR_CHANGE_PARAM"),
    /*  593 */
    STR_PIEB_MODE_IN_EFFECT(Integer.valueOf(577), "STR_PIEB_MODE_IN_EFFECT"),
    /*  594 */
    STR_STANDBY_SET_TIME(Integer.valueOf(578), "STR_STANDBY_SET_TIME"),
    /*  595 */
    STR_CHANGE_STANDBY_TIME(Integer.valueOf(579), "STR_CHANGE_STANDBY_TIME"),
    /*  596 */
    STR_SINGLE_S(Integer.valueOf(580), "STR_SINGLE_S"),
    /*  597 */
    STR_ALARM_MCU(Integer.valueOf(581), "STR_ALARM_MCU"),
    /*  598 */
    STR_INFUSION_STATE(Integer.valueOf(582), "STR_INFUSION_STATE"),
    /*  599 */
    STR_MODE_CONFIG(Integer.valueOf(583), "STR_MODE_CONFIG"),
    /*  600 */
    STR_CLIN_BOLUS_VI(Integer.valueOf(584), "STR_CLIN_BOLUS_VI"),
    /*  601 */
    STR_RENAME_PROGRAM(Integer.valueOf(585), "STR_RENAME_PROGRAM"),
    /*  602 */
    STR_TIP_DELETE_PROGRAM(Integer.valueOf(586), "STR_TIP_DELETE_PROGRAM"),
    /*  603 */
    STR_CLIN_BOLUS_MODE(Integer.valueOf(587), "STR_CLIN_BOLUS_MODE"),
    /*  604 */
    STR_AUTO_C_BOLUS(Integer.valueOf(588), "STR_AUTO_C_BOLUS"),
    /*  605 */
    STR_SEMI_C_BOLUS(Integer.valueOf(589), "STR_SEMI_C_BOLUS"),
    /*  606 */
    STR_C_BOLUS(Integer.valueOf(590), "STR_C_BOLUS"),
    /*  607 */
    STR_DEF_BOLUS(Integer.valueOf(591), "STR_DEF_BOLUS"),
    /*  608 */
    STR_MANUAL_BOLUS_LIMIT(Integer.valueOf(592), "STR_MANUAL_BOLUS_LIMIT"),
    /*  609 */
    STR_PROGRAM_NOT_AVAILABLE(Integer.valueOf(593), "STR_PROGRAM_NOT_AVAILABLE"),
    /*  610 */
    STR_SAVE_PROGRAM(Integer.valueOf(594), "STR_SAVE_PROGRAM"),
    /*  611 */
    STR_DELETE_PROGRAM(Integer.valueOf(595), "STR_DELETE_PROGRAM"),
    /*  612 */
    STR_SAVE(Integer.valueOf(596), "STR_SAVE"),
    /*  613 */
    STR_DELETE(Integer.valueOf(597), "STR_DELETE"),
    /*  614 */
    STR_CONFIRM_BUTTON_FAULT(Integer.valueOf(598), "STR_CONFIRM_BUTTON_FAULT"),
    /*  615 */
    STR_CONFIRM_INSUF_ANALGESIA(Integer.valueOf(599), "STR_CONFIRM_INSUF_ANALGESIA"),
    /*  616 */
    STR_TIP_RESET_FACTORY(Integer.valueOf(600), "STR_TIP_RESET_FACTORY"),
    /*  617 */
    STR_TIP_CLEAR_EVENT_LOG(Integer.valueOf(601), "STR_TIP_CLEAR_EVENT_LOG"),
    /*  618 */
    STR_BRIGHTNESS_VOLUME(Integer.valueOf(602), "STR_BRIGHTNESS_VOLUME"),
    /*  619 */
    STR_FIRST_LOG(Integer.valueOf(603), "STR_FIRST_LOG"),
    /*  620 */
    STR_LAST_LOG(Integer.valueOf(604), "STR_LAST_LOG"),
    /*  621 */
    STR_CLEAR_ACCUM_VI(Integer.valueOf(605), "STR_CLEAR_ACCUM_VI"),
    /*  622 */
    STR_PARAM_NOT_SAVED(Integer.valueOf(606), "STR_PARAM_NOT_SAVED"),
    /*  623 */
    STR_POSTOPERATIVE(Integer.valueOf(607), "STR_POSTOPERATIVE"),
    /*  624 */
    STR_LABOUR(Integer.valueOf(608), "STR_LABOUR"),
    /*  625 */
    STR_CANCER(Integer.valueOf(609), "STR_CANCER"),
    /*  626 */
    STR_NEW_PAT_LOGIN_SYSTEM(Integer.valueOf(610), "STR_NEW_PAT_LOGIN_SYSTEM"),
    /*  627 */
    STR_LOGIN_SYSTEM(Integer.valueOf(611), "STR_LOGIN_SYSTEM"),
    /*  628 */
    STR_LOGIN_TIP(Integer.valueOf(612), "STR_LOGIN_TIP"),
    /*  629 */
    STR_WEIGHT_CHANGE(Integer.valueOf(613), "STR_WEIGHT_CHANGE"),
    /*  630 */
    STR_BSA_CHANGE(Integer.valueOf(614), "STR_BSA_CHANGE"),
    /*  631 */
    STR_NO_PATIENT(Integer.valueOf(615), "STR_NO_PATIENT"),
    /*  632 */
    STR_NO_RX(Integer.valueOf(616), "STR_NO_RX"),
    /*  633 */
    STR_LOADING_TIME_2(Integer.valueOf(617), "STR_LOADING_TIME_2"),
    /*  634 */
    STR_LOADING_DOSE_2(Integer.valueOf(618), "STR_LOADING_DOSE_2"),
    /*  635 */
    STR_LOCKOUT_TIME_2(Integer.valueOf(619), "STR_LOCKOUT_TIME_2"),
    /*  636 */
    STR_VERSION_INFO(Integer.valueOf(620), "STR_VERSION_INFO"),
    /*  637 */
    STR_DATASET_VERSION(Integer.valueOf(621), "STR_DATASET_VERSION"),
    /*  638 */
    STR_SVN_VERSION(Integer.valueOf(622), "STR_SVN_VERSION"),
    /*  639 */
    STR_TIP_EDIT_PARAM_NOT_SAVE(Integer.valueOf(623), "STR_TIP_EDIT_PARAM_NOT_SAVE"),
    /*  640 */
    STR_KEY_FOR_AGING(Integer.valueOf(624), "STR_KEY_FOR_AGING"),
    /*  641 */
    STR_TIP_AGING(Integer.valueOf(625), "STR_TIP_AGING"),
    /*  642 */
    STR_MAINTAIN_TIME_2(Integer.valueOf(626), "STR_MAINTAIN_TIME_2"),
    /*  643 */
    STR_TIP_PATIENT_RECEIVED(Integer.valueOf(627), "STR_TIP_PATIENT_RECEIVED"),
    /*  644 */
    STR_CONFIRM_PARAM_NOT_SAVED(Integer.valueOf(628), "STR_CONFIRM_PARAM_NOT_SAVED"),
    /*  645 */
    STR_DATASET_NAME(Integer.valueOf(629), "STR_DATASET_NAME"),
    /*  646 */
    STR_POWER_ON_LOGO(Integer.valueOf(630), "STR_POWER_ON_LOGO"),
    /*  647 */
    STR_TIME_ZONE(Integer.valueOf(631), "STR_TIME_ZONE"),
    /*  648 */
    STR_NTP_SERVER(Integer.valueOf(632), "STR_NTP_SERVER"),
    /*  649 */
    STR_NTP_STATUS(Integer.valueOf(633), "STR_NTP_STATUS"),
    /*  650 */
    STR_DISCONNECTED(Integer.valueOf(634), "STR_DISCONNECTED"),
    /*  651 */
    STR_DATASET_CHECK_PASS(Integer.valueOf(635), "STR_DATASET_CHECK_PASS"),
    /*  652 */
    STR_DATASET_CHECK_FAILED(Integer.valueOf(636), "STR_DATASET_CHECK_FAILED"),
    /*  653 */
    STR_DOSECONTROL(Integer.valueOf(637), "STR_DOSECONTROL"),
    /*  654 */
    STR_REGULAR_INFUSION(Integer.valueOf(638), "STR_REGULAR_INFUSION"),
    /*  655 */
    STR_DRUG_SEARCH(Integer.valueOf(639), "STR_DRUG_SEARCH"),
    /*  656 */
    STR_SEARCH_BY(Integer.valueOf(640), "STR_SEARCH_BY"),
    /*  657 */
    STR_CLINICAL_ADVICE(Integer.valueOf(641), "STR_CLINICAL_ADVICE"),
    /*  658 */
    STR_PROFILE(Integer.valueOf(642), "STR_PROFILE"),
    /*  659 */
    STR_TIP_SELECT_PROFILE(Integer.valueOf(643), "STR_TIP_SELECT_PROFILE"),
    /*  660 */
    STR_OTHER(Integer.valueOf(644), "STR_OTHER"),
    /*  661 */
    STR_PROFILE_EFFECT(Integer.valueOf(645), "STR_PROFILE_EFFECT"),
    /*  662 */
    STR_ENTER_DOSECONTROL(Integer.valueOf(646), "STR_ENTER_DOSECONTROL"),
    /*  663 */
    STR_EXIT_DOSECONTROL(Integer.valueOf(647), "STR_EXIT_DOSECONTROL"),
    /*  664 */
    STR_CONFIRM_DRUG(Integer.valueOf(648), "STR_CONFIRM_DRUG"),
    /*  665 */
    STR_DEFAULT(Integer.valueOf(649), "STR_DEFAULT"),
    /*  666 */
    STR_HARD_UPPER_LIMIT(Integer.valueOf(650), "STR_HARD_UPPER_LIMIT"),
    /*  667 */
    STR_SOFT_UPPER_LIMIT(Integer.valueOf(651), "STR_SOFT_UPPER_LIMIT"),
    /*  668 */
    STR_SOFT_LOWER_LIMIT(Integer.valueOf(652), "STR_SOFT_LOWER_LIMIT"),
    /*  669 */
    STR_INPUT(Integer.valueOf(653), "STR_INPUT"),
    /*  670 */
    STR_RESPONSE(Integer.valueOf(654), "STR_RESPONSE"),
    /*  671 */
    STR_ACCEPT(Integer.valueOf(655), "STR_ACCEPT"),
    /*  672 */
    STR_REJECT(Integer.valueOf(656), "STR_REJECT"),
    /*  673 */
    STR_UUID(Integer.valueOf(657), "STR_UUID"),
    /*  674 */
    STR_TIP_SOFT_MAX_EXCEED(Integer.valueOf(658), "STR_TIP_SOFT_MAX_EXCEED"),
    /*  675 */
    STR_TIP_SOFT_MIN_EXCEED(Integer.valueOf(659), "STR_TIP_SOFT_MIN_EXCEED"),
    /*  676 */
    STR_DRUG_CLASSIFICATION(Integer.valueOf(660), "STR_DRUG_CLASSIFICATION"),
    /*  677 */
    STR_CUSTOM_CONC(Integer.valueOf(661), "STR_CUSTOM_CONC"),
    /*  678 */
    STR_EVENT_ERR_301(Integer.valueOf(662), "STR_EVENT_ERR_301"),
    /*  679 */
    STR_REALTIME_AD(Integer.valueOf(663), "STR_REALTIME_AD"),
    /*  680 */
    STR_SUSPENDED_AD(Integer.valueOf(664), "STR_SUSPENDED_AD"),
    /*  681 */
    STR_TUBULATURE_AD(Integer.valueOf(665), "STR_TUBULATURE_AD"),
    /*  682 */
    STR_ALARM_AD(Integer.valueOf(666), "STR_ALARM_AD"),
    /*  683 */
    STR_CALIBRATION_FAIL(Integer.valueOf(667), "STR_CALIBRATION_FAIL"),
    /*  684 */
    STR_DOWNTUBULATURE_CALI(Integer.valueOf(668), "STR_DOWNTUBULATURE_CALI"),
    /*  685 */
    STR_START_CALI(Integer.valueOf(669), "STR_START_CALI"),
    /*  686 */
    STR_OBTAIN(Integer.valueOf(670), "STR_OBTAIN"),
    /*  687 */
    STR_UPTUBULATURE_CALI(Integer.valueOf(671), "STR_UPTUBULATURE_CALI"),
    /*  688 */
    STR_DOWNOCCL_CALI(Integer.valueOf(672), "STR_DOWNOCCL_CALI"),
    /*  689 */
    STR_L1_PRESURE(Integer.valueOf(673), "STR_L1_PRESURE"),
    /*  690 */
    STR_L2_PRESURE(Integer.valueOf(674), "STR_L2_PRESURE"),
    /*  691 */
    STR_L3_PRESURE(Integer.valueOf(675), "STR_L3_PRESURE"),
    /*  692 */
    STR_L1_AD(Integer.valueOf(676), "STR_L1_AD"),
    /*  693 */
    STR_L2_AD(Integer.valueOf(677), "STR_L2_AD"),
    /*  694 */
    STR_L3_AD(Integer.valueOf(678), "STR_L3_AD"),
    /*  695 */
    STR_SOFTWARE_DIFFERENCE(Integer.valueOf(679), "STR_SOFTWARE_DIFFERENCE"),
    /*  696 */
    STR_CHINA(Integer.valueOf(680), "STR_CHINA"),
    /*  697 */
    STR_INTERNATIONAL(Integer.valueOf(681), "STR_INTERNATIONAL"),
    /*  698 */
    STR_MAINTENANCE_REMINDER(Integer.valueOf(682), "STR_MAINTENANCE_REMINDER"),
    /*  699 */
    STR_MAINT_CYCLE(Integer.valueOf(683), "STR_MAINT_CYCLE"),
    /*  700 */
    STR_START_DATE(Integer.valueOf(684), "STR_START_DATE"),
    /*  701 */
    STR_NEXT_REMINDER(Integer.valueOf(685), "STR_NEXT_REMINDER"),
    /*  702 */
    STR_RESET(Integer.valueOf(686), "STR_RESET"),
    /*  703 */
    STR_WHETHER_TO_RESET_THE_START_DATE(Integer.valueOf(687), "STR_WHETHER_TO_RESET_THE_START_DATE"),
    /*  704 */
    STR_MAINTENANCE_TIME_ARRIVED_PLEASE_CONTACT_THE_MANUFACTURER_TO_MAINTAIN(Integer.valueOf(688), "STR_MAINTENANCE_TIME_ARRIVED_PLEASE_CONTACT_THE_MANUFACTURER_TO_MAINTAIN"),
    /*  705 */
    STR_TIP_PROFILE_NO_INFUSION(Integer.valueOf(689), "STR_TIP_PROFILE_NO_INFUSION"),
    /*  706 */
    STR_OOCL_CALI_750(Integer.valueOf(690), "STR_OOCL_CALI_750"),
    /*  707 */
    STR_OOCL_CALI_1125(Integer.valueOf(691), "STR_OOCL_CALI_1125"),
    /*  708 */
    STR_OOCL_CALI_1500(Integer.valueOf(692), "STR_OOCL_CALI_1500"),
    /*  709 */
    STR_TIP_SELCET_ELFENSOR(Integer.valueOf(693), "STR_TIP_SELCET_ELFENSOR"),
    /*  710 */
    STR_TIP_LOCKOUTTIME_NULL(Integer.valueOf(694), "STR_TIP_LOCKOUTTIME_NULL"),
    /*  711 */
    STR_BOLUS_DOSE(Integer.valueOf(695), "STR_BOLUS_DOSE"),
    /*  712 */
    STR_MANUAL_C_BOLUS(Integer.valueOf(696), "STR_MANUAL_C_BOLUS"),
    /*  713 */
    STR_CUSTOM(Integer.valueOf(697), "STR_CUSTOM"),
    /*  714 */
    STR_TIP_C_BOLUS_VI(Integer.valueOf(698), "STR_TIP_C_BOLUS_VI"),
    /*  715 */
    STR_BUTTON_HOLD_TO_START(Integer.valueOf(699), "STR_BUTTON_HOLD_TO_START"),
    /*  716 */
    STR_PAUSE_BOLUS(Integer.valueOf(700), "STR_PAUSE_BOLUS"),
    /*  717 */
    STR_C_BOLUS_DOSE_VI(Integer.valueOf(701), "STR_C_BOLUS_DOSE_VI"),
    /*  718 */
    STR_EXIT_BOLUS(Integer.valueOf(702), "STR_EXIT_BOLUS"),
    /*  719 */
    STR_CLEAR_DATASET(Integer.valueOf(703), "STR_CLEAR_DATASET"),
    /*  720 */
    STR_TIP_CLEAR_DATASET(Integer.valueOf(704), "STR_TIP_CLEAR_DATASET"),
    /*  721 */
    STR_TIP_DEFAULT(Integer.valueOf(705), "STR_TIP_DEFAULT"),
    /*  722 */
    STR_UPPERLIMIT_EXCEEDED(Integer.valueOf(706), "STR_UPPERLIMIT_EXCEEDED"),
    /*  723 */
    STR_LOWERLIMIT_EXCEEDED(Integer.valueOf(707), "STR_LOWERLIMIT_EXCEEDED"),
    /*  724 */
    STR_CONTINUE_C_BOLUS(Integer.valueOf(708), "STR_CONTINUE_C_BOLUS"),
    /*  725 */
    STR_MANUAL_BOLUS_REACH_LIMIT(Integer.valueOf(709), "STR_MANUAL_BOLUS_REACH_LIMIT"),
    /*  726 */
    STR_TIP_HARD_MIN_EXCEED(Integer.valueOf(710), "STR_TIP_HARD_MIN_EXCEED"),
    /*  727 */
    STR_TIP_CONFIRM_WEIGHT(Integer.valueOf(711), "STR_TIP_CONFIRM_WEIGHT"),
    /*  728 */
    STR_TIP_CONFIRM_BSA(Integer.valueOf(712), "STR_TIP_CONFIRM_BSA"),
    /*  729 */
    STR_EVENT_SET(Integer.valueOf(713), "STR_EVENT_SET"),
    /*  730 */
    STR_HARD_LOWER_LIMIT(Integer.valueOf(714), "STR_HARD_LOWER_LIMIT"),
    /*  731 */
    STR_DISPLAY_PWD(Integer.valueOf(715), "STR_DISPLAY_PWD"),
    /*  732 */
    STR_EVENT_SOFT_MIN_EXCEED(Integer.valueOf(716), "STR_EVENT_SOFT_MIN_EXCEED"),
    /*  733 */
    STR_EVENT_SOFT_MAX_EXCEED(Integer.valueOf(717), "STR_EVENT_SOFT_MAX_EXCEED"),
    /*  734 */
    STR_EVENT_HARD_MIN_EXCEED(Integer.valueOf(718), "STR_EVENT_HARD_MIN_EXCEED"),
    /*  735 */
    STR_CONFIRM_MODE(Integer.valueOf(719), "STR_CONFIRM_MODE"),
    /*  736 */
    STR_ACCURACY_TEST(Integer.valueOf(720), "STR_ACCURACY_TEST"),
    /*  737 */
    STR_TIP_ACCURACY_TEST(Integer.valueOf(721), "STR_TIP_ACCURACY_TEST"),
    /*  738 */
    STR_SCANNER_TEST(Integer.valueOf(722), "STR_SCANNER_TEST"),
    /*  739 */
    STR_BARCODE_CONTENT(Integer.valueOf(723), "STR_BARCODE_CONTENT"),
    /*  740 */
    STR_TIP_CASS_UNLOCK(Integer.valueOf(724), "STR_TIP_CASS_UNLOCK"),
    /*  741 */
    STR_TIP_CASS_DETACHED(Integer.valueOf(725), "STR_TIP_CASS_DETACHED"),
    /*  742 */
    STR_ADMIT_RX(Integer.valueOf(726), "STR_ADMIT_RX"),
    /*  743 */
    STR_ENTER_PID(Integer.valueOf(727), "STR_ENTER_PID"),
    /*  744 */
    STR_PLEASE_ENTER_PID(Integer.valueOf(728), "STR_PLEASE_ENTER_PID"),
    /*  745 */
    STR_PCA_TONE(Integer.valueOf(729), "STR_PCA_TONE"),
    /*  746 */
    STR_NO_TONE(Integer.valueOf(730), "STR_NO_TONE"),
    /*  747 */
    STR_SAME_TONE(Integer.valueOf(731), "STR_SAME_TONE"),
    /*  748 */
    STR_DIFFERENT_TONE(Integer.valueOf(732), "STR_DIFFERENT_TONE"),
    /*  749 */
    STR_ONLY_FOR_VAILD(Integer.valueOf(733), "STR_ONLY_FOR_VAILD"),
    /*  750 */
    STR_RESET_MAINT_REMINDER(Integer.valueOf(734), "STR_RESET_MAINT_REMINDER"),
    /*  751 */
    STR_CLOSE_MAINT_REMINDER(Integer.valueOf(735), "STR_CLOSE_MAINT_REMINDER"),
    /*  752 */
    STR_CLASSIFICATION(Integer.valueOf(736), "STR_CLASSIFICATION"),
    /*  753 */
    STR_M_REMINDER(Integer.valueOf(737), "STR_M_REMINDER"),
    /*  754 */
    STR_RESTART_DURING_INFUSION(Integer.valueOf(738), "STR_RESTART_DURING_INFUSION"),
    /*  755 */
    STR_ERR_408(Integer.valueOf(739), "STR_ERR_408"),
    /*  756 */
    STR_AIR_DETECTOR(Integer.valueOf(740), "STR_AIR_DETECTOR"),
    /*  757 */
    STR_UNDERDOSE_TIP(Integer.valueOf(741), "STR_UNDERDOSE_TIP"),
    /*  758 */
    STR_PCA_DOSE_CTRL_CONN_TIP(Integer.valueOf(742), "STR_PCA_DOSE_CTRL_CONN_TIP"),
    /*  759 */
    STR_CMS_DISCONNECTED_CANNOT_UPGRADE(Integer.valueOf(743), "STR_CMS_DISCONNECTED_CANNOT_UPGRADE"),
    /*  760 */
    STR_LOW_BATTERY_BATTERY_CANOT_UPGRADE(Integer.valueOf(744), "STR_LOW_BATTERY_BATTERY_CANOT_UPGRADE"),
    /*  761 */
    STR_DONT_EXIT_DURING_TOT_UPGRADE(Integer.valueOf(745), "STR_DONT_EXIT_DURING_TOT_UPGRADE"),
    /*  762 */
    STR_UPGRADE_POWEROT_OFF(Integer.valueOf(746), "STR_UPGRADE_POWEROT_OFF"),
    /*  763 */
    STR_ERR_EXIST_CANNTOT_UPGRADE(Integer.valueOf(747), "STR_ERR_EXIST_CANNTOT_UPGRADE"),
    /*  764 */
    STR_UPGRADE_SUCCESS(Integer.valueOf(748), "STR_UPGRADE_SUCCESS"),
    /*  765 */
    STR_UPGRADE_FAILED(Integer.valueOf(749), "STR_UPGRADE_FAILED"),
    /*  766 */
    STR_UPGRADE_TIP(Integer.valueOf(750), "STR_UPGRADE_TIP"),
    /*  767 */
    STR_FAILED_PARSE(Integer.valueOf(751), "STR_FAILED_PARSE"),
    /*  768 */
    STR_FAILED_OBTAIN(Integer.valueOf(752), "STR_FAILED_OBTAIN"),
    /*  769 */
    STR_DEVELOPMENT_INFO(Integer.valueOf(753), "STR_DEVELOPMENT_INFO"),
    /*  770 */
    STR_30MIN_LOCK(Integer.valueOf(754), "STR_30MIN_LOCK"),
    /*  771 */
    STR_LEFT_CHANCE(Integer.valueOf(755), "STR_LEFT_CHANCE"),
    /*  772 */
    STR_PWD_LOGIN(Integer.valueOf(756), "STR_PWD_LOGIN"),
    /*  773 */
    STR_MANUFACTURER(Integer.valueOf(757), "STR_MANUFACTURER"),
    /*  774 */
    STR_ACTIVE(Integer.valueOf(758), "STR_ACTIVE"),
    /*  775 */
    STR_EVENT_PUMP_LOCK(Integer.valueOf(759), "STR_EVENT_PUMP_LOCK"),
    /*  776 */
    STR_ALARM_ACTIVE(Integer.valueOf(760), "STR_ALARM_ACTIVE"),
    /*  777 */
    STR_MFR_PED(Integer.valueOf(761), "STR_MFR_PED"),
    /*  778 */
    STR_SHORT_COM_INTERRUPTED(Integer.valueOf(762), "STR_SHORT_COM_INTERRUPTED"),
    /*  779 */
    STR_DELAY_START(Integer.valueOf(763), "STR_DELAY_START"),
    /*  780 */
    STR_EXIT_DELAY(Integer.valueOf(764), "STR_EXIT_DELAY"),
    /*  781 */
    STR_CHANGE_DELAY_TIME(Integer.valueOf(765), "STR_CHANGE_DELAY_TIME"),
    /*  782 */
    STR_START_INFUSION(Integer.valueOf(766), "STR_START_INFUSION"),
    /*  783 */
    STR_EVENT_ERR_306(Integer.valueOf(767), "STR_EVENT_ERR_306"),
    /*  784 */
    STR_REASON(Integer.valueOf(768), "STR_REASON"),
    /*  785 */
    STR_CERTIFICATE_INFO(Integer.valueOf(769), "STR_CERTIFICATE_INFO"),
    /*  786 */
    STR_APPLY_CERT(Integer.valueOf(770), "STR_APPLY_CERT"),
    /*  787 */
    STR_VIEW_CERT(Integer.valueOf(771), "STR_VIEW_CERT"),
    /*  788 */
    STR_TIP_CERTIFICATE_ALREADY_EXISTS(Integer.valueOf(772), "STR_TIP_CERTIFICATE_ALREADY_EXISTS"),
    /*  789 */
    STR_TIP_IS_NO_CERTIFICATE(Integer.valueOf(773), "STR_TIP_IS_NO_CERTIFICATE"),
    /*  790 */
    STR_TIP_ENTER_SN(Integer.valueOf(774), "STR_TIP_ENTER_SN"),
    /*  791 */
    STR_TIP_APPLY_CERTIFICATE(Integer.valueOf(775), "STR_TIP_APPLY_CERTIFICATE"),
    /*  792 */
    STR_UPGRADE_TERMINATED(Integer.valueOf(776), "STR_UPGRADE_TERMINATED"),
    /*  793 */
    STR_REFRESH_COMPLETE(Integer.valueOf(777), "STR_REFRESH_COMPLETE"),
    /*  794 */
    STR_MAC_ADDRESS(Integer.valueOf(778), "STR_MAC_ADDRESS"),
    /*  795 */
    STR_OCCL_EMPTY_CALI(Integer.valueOf(779), "STR_OCCL_EMPTY_CALI"),
    /*  796 */
    STR_UP_REALTIME_AD(Integer.valueOf(780), "STR_UP_REALTIME_AD"),
    /*  797 */
    STR_DOWN_REALTIME_AD(Integer.valueOf(781), "STR_DOWN_REALTIME_AD"),
    /*  798 */
    STR_UP_EMPTY_AD(Integer.valueOf(782), "STR_UP_EMPTY_AD"),
    /*  799 */
    STR_DOWN_EMPTY_AD(Integer.valueOf(783), "STR_DOWN_EMPTY_AD"),
    /*  800 */
    STR_CALIBRATION_VALUE(Integer.valueOf(784), "STR_CALIBRATION_VALUE"),
    /*  801 */
    STR_ALARM_HELP_PATIENTSIDE(Integer.valueOf(785), "STR_ALARM_HELP_PATIENTSIDE"),
    /*  802 */
    STR_ALARM_HELP_FLUIDSIDE(Integer.valueOf(786), "STR_ALARM_HELP_FLUIDSIDE"),
    /*  803 */
    STR_ALARM_HELP_REINSTALL_CASSETTE(Integer.valueOf(787), "STR_ALARM_HELP_REINSTALL_CASSETTE"),
    /*      */
    /*  805 */
    STR_SEQUE_S1_VTBI(Integer.valueOf(9000), "STR_SEQUE_S1_VTBI"),
    /*  806 */
    STR_SEQUE_S2_VTBI(Integer.valueOf(9001), "STR_SEQUE_S2_VTBI"),
    /*  807 */
    STR_SEQUE_S3_VTBI(Integer.valueOf(9002), "STR_SEQUE_S3_VTBI"),
    /*  808 */
    STR_SEQUE_S4_VTBI(Integer.valueOf(9003), "STR_SEQUE_S4_VTBI"),
    /*  809 */
    STR_SEQUE_S5_VTBI(Integer.valueOf(9004), "STR_SEQUE_S5_VTBI"),
    /*  810 */
    STR_SEQUE_S6_VTBI(Integer.valueOf(9005), "STR_SEQUE_S6_VTBI"),
    /*  811 */
    STR_SEQUE_S7_VTBI(Integer.valueOf(9006), "STR_SEQUE_S7_VTBI"),
    /*  812 */
    STR_SEQUE_S8_VTBI(Integer.valueOf(9007), "STR_SEQUE_S8_VTBI"),
    /*  813 */
    STR_SEQUE_S9_VTBI(Integer.valueOf(9008), "STR_SEQUE_S9_VTBI"),
    /*  814 */
    STR_SEQUE_S10_VTBI(Integer.valueOf(9009), "STR_SEQUE_S10_VTBI"),
    /*      */
    /*  816 */
    STR_SEQUE_RATE_S1_RATE(Integer.valueOf(9010), "STR_SEQUE_RATE_S1_RATE"),
    /*  817 */
    STR_SEQUE_RATE_S2_RATE(Integer.valueOf(9011), "STR_SEQUE_RATE_S2_RATE"),
    /*  818 */
    STR_SEQUE_RATE_S3_RATE(Integer.valueOf(9012), "STR_SEQUE_RATE_S3_RATE"),
    /*  819 */
    STR_SEQUE_RATE_S4_RATE(Integer.valueOf(9013), "STR_SEQUE_RATE_S4_RATE"),
    /*  820 */
    STR_SEQUE_RATE_S5_RATE(Integer.valueOf(9014), "STR_SEQUE_RATE_S5_RATE"),
    /*  821 */
    STR_SEQUE_RATE_S6_RATE(Integer.valueOf(9015), "STR_SEQUE_RATE_S6_RATE"),
    /*  822 */
    STR_SEQUE_RATE_S7_RATE(Integer.valueOf(9016), "STR_SEQUE_RATE_S7_RATE"),
    /*  823 */
    STR_SEQUE_RATE_S8_RATE(Integer.valueOf(9017), "STR_SEQUE_RATE_S8_RATE"),
    /*  824 */
    STR_SEQUE_RATE_S9_RATE(Integer.valueOf(9018), "STR_SEQUE_RATE_S9_RATE"),
    /*  825 */
    STR_SEQUE_RATE_S10_RATE(Integer.valueOf(9019), "STR_SEQUE_RATE_S10_RATE"),
    /*      */
    /*  827 */
    STR_SEQUE_S1_TIME(Integer.valueOf(9020), "STR_SEQUE_S1_TIME"),
    /*  828 */
    STR_SEQUE_S2_TIME(Integer.valueOf(9021), "STR_SEQUE_S2_TIME"),
    /*  829 */
    STR_SEQUE_S3_TIME(Integer.valueOf(9022), "STR_SEQUE_S3_TIME"),
    /*  830 */
    STR_SEQUE_S4_TIME(Integer.valueOf(9023), "STR_SEQUE_S4_TIME"),
    /*  831 */
    STR_SEQUE_S5_TIME(Integer.valueOf(9024), "STR_SEQUE_S5_TIME"),
    /*  832 */
    STR_SEQUE_S6_TIME(Integer.valueOf(9025), "STR_SEQUE_S6_TIME"),
    /*  833 */
    STR_SEQUE_S7_TIME(Integer.valueOf(9026), "STR_SEQUE_S7_TIME"),
    /*  834 */
    STR_SEQUE_S8_TIME(Integer.valueOf(9027), "STR_SEQUE_S8_TIME"),
    /*  835 */
    STR_SEQUE_S9_TIME(Integer.valueOf(9028), "STR_SEQUE_S9_TIME"),
    /*  836 */
    STR_SEQUE_S10_TIME(Integer.valueOf(9029), "STR_SEQUE_S10_TIME"),
    /*      */
    /*  838 */
    STR_DRUG_VOLUME_EVENT_SET(Integer.valueOf(9031), "STR_DRUG_VOLUME_EVENT_SET"),
    /*  839 */
    STR_DRUG_AMOUNT_EVENT_SET(Integer.valueOf(9032), "STR_DRUG_AMOUNT_EVENT_SET"),
    /*  840 */
    STR_DRUG_CONC_EVENT_SET(Integer.valueOf(9033), "STR_DRUG_CONC_EVENT_SET"),
    /*  841 */
    STR_HEIGHT_EVENT_SET(Integer.valueOf(9034), "STR_HEIGHT_EVENT_SET"),
    /*  842 */
    STR_WEIGHT_EVENT_SET(Integer.valueOf(9035), "STR_WEIGHT_EVENT_SET"),
    /*  843 */
    STR_BSA_EVENT_SET(Integer.valueOf(9036), "STR_BSA_EVENT_SET"),
    /*  844 */
    STR_RATE_EVENT_SET(Integer.valueOf(9037), "STR_RATE_EVENT_SET"),
    /*  845 */
    STR_VTBI_EVENT_SET(Integer.valueOf(9038), "STR_VTBI_EVENT_SET"),
    /*  846 */
    STR_TIME_EVENT_SET(Integer.valueOf(9039), "STR_TIME_EVENT_SET"),
    /*  847 */
    STR_LOADING_DOSE_EVENT_SET(Integer.valueOf(9040), "STR_LOADING_DOSE_EVENT_SET"),
    /*  848 */
    STR_CONTINUOUS_RATE_EVENT_SET(Integer.valueOf(9041), "STR_CONTINUOUS_RATE_EVENT_SET"),
    /*  849 */
    STR_INFUSION_PARAMETER_PCA_DOSE_EVENT_SET(Integer.valueOf(9042), "STR_INFUSION_PARAMETER_PCA_DOSE_EVENT_SET"),
    /*  850 */
    STR_LOCKOUT_TIME_EVENT_SET(Integer.valueOf(9043), "STR_LOCKOUT_TIME_EVENT_SET"),
    /*  851 */
    STR_SWITCH_DOSE_LMT_EVENT_SET(Integer.valueOf(9044), "STR_SWITCH_DOSE_LMT_EVENT_SET"),
    /*  852 */
    STR_CONTINOUS_DOSE_RATE_EVENT_SET(Integer.valueOf(9045), "STR_CONTINOUS_DOSE_RATE_EVENT_SET"),
    /*  853 */
    STR_DEMAND_DOSE_EVENT_SET(Integer.valueOf(9046), "STR_DEMAND_DOSE_EVENT_SET"),
    /*  854 */
    STR_DOSE_LIMIT_EVENT_SET(Integer.valueOf(9047), "STR_DOSE_LIMIT_EVENT_SET"),
    /*  855 */
    STR_SCREEN_PIEB_NEXT_BOLUS_EVENT_SET(Integer.valueOf(9048), "STR_SCREEN_PIEB_NEXT_BOLUS_EVENT_SET"),
    /*  856 */
    STR_INFUSION_PARAMETER_PIEB_DOSE_EVENT_SET(Integer.valueOf(9049), "STR_INFUSION_PARAMETER_PIEB_DOSE_EVENT_SET"),
    /*  857 */
    STR_INFUSION_PARAMETER_PIEB_INTERVAL_EVENT_SET(Integer.valueOf(9050), "STR_INFUSION_PARAMETER_PIEB_INTERVAL_EVENT_SET"),
    /*  858 */
    STR_LOADING_RATE_EVENT_SET(Integer.valueOf(9052), "STR_LOADING_RATE_EVENT_SET"),
    /*  859 */
    STR_MAINTAIN_RATE_EVENT_SET(Integer.valueOf(9053), "STR_MAINTAIN_RATE_EVENT_SET"),
    /*  860 */
    STR_LOADING_TIME_EVENT_SET(Integer.valueOf(9054), "STR_LOADING_TIME_EVENT_SET"),
    /*  861 */
    STR_MAINTAIN_TIME_EVENT_SET(Integer.valueOf(9055), "STR_MAINTAIN_TIME_EVENT_SET"),
    /*  862 */
    STR_BOULS_VOL_EVENT_SET(Integer.valueOf(9056), "STR_BOULS_VOL_EVENT_SET"),
    /*  863 */
    STR_BOULS_RATE_EVENT_SET(Integer.valueOf(9057), "STR_BOULS_RATE_EVENT_SET"),
    /*  864 */
    STR_INFUSION_INTERVAL_EVENT_SET(Integer.valueOf(9058), "STR_INFUSION_INTERVAL_EVENT_SET"),
    /*  865 */
    STR_SINGLE_DOSE_EVENT_SET(Integer.valueOf(9059), "STR_SINGLE_DOSE_EVENT_SET"),
    /*  866 */
    STR_SINGLE_DOSE_RATE_EVENT_SET(Integer.valueOf(9060), "STR_SINGLE_DOSE_RATE_EVENT_SET"),
    /*  867 */
    STR_TOTAL_TIME_EVENT_SET(Integer.valueOf(9061), "STR_TOTAL_TIME_EVENT_SET"),
    /*  868 */
    STR_STABLE_RATE_EVENT_SET(Integer.valueOf(9062), "STR_STABLE_RATE_EVENT_SET"),
    /*  869 */
    STR_RISE_TIME_EVENT_SET(Integer.valueOf(9063), "STR_RISE_TIME_EVENT_SET"),
    /*  870 */
    STR_FALL_TIME_EVENT_SET(Integer.valueOf(9064), "STR_FALL_TIME_EVENT_SET"),
    /*  871 */
    STR_DOSE_RATE_EVENT_SET(Integer.valueOf(9065), "STR_DOSE_RATE_EVENT_SET"),
    /*  872 */
    STR_INFUSION_RATE_EVENT_SET(Integer.valueOf(9066), "STR_INFUSION_RATE_EVENT_SET"),
    /*  873 */
    STR_ACCUMULATED_VOLUME_EVENT_SET(Integer.valueOf(9067), "STR_ACCUMULATED_VOLUME_EVENT_SET"),
    /*  874 */
    STR_ACCUMULATED_TIME_EVENT_SET(Integer.valueOf(9068), "STR_ACCUMULATED_TIME_EVENT_SET"),
    /*  875 */
    STR_STAGE_S1_RATE_EVENT_SET(Integer.valueOf(9069), "STR_STAGE_S1_RATE_EVENT_SET"),
    /*  876 */
    STR_STAGE_S2_RATE_EVENT_SET(Integer.valueOf(9070), "STR_STAGE_S2_RATE_EVENT_SET"),
    /*  877 */
    STR_STAGE_S3_RATE_EVENT_SET(Integer.valueOf(9071), "STR_STAGE_S3_RATE_EVENT_SET"),
    /*  878 */
    STR_STAGE_S4_RATE_EVENT_SET(Integer.valueOf(9072), "STR_STAGE_S4_RATE_EVENT_SET"),
    /*  879 */
    STR_STAGE_S5_RATE_EVENT_SET(Integer.valueOf(9073), "STR_STAGE_S5_RATE_EVENT_SET"),
    /*  880 */
    STR_STAGE_S6_RATE_EVENT_SET(Integer.valueOf(9074), "STR_STAGE_S6_RATE_EVENT_SET"),
    /*  881 */
    STR_STAGE_S7_RATE_EVENT_SET(Integer.valueOf(9075), "STR_STAGE_S7_RATE_EVENT_SET"),
    /*  882 */
    STR_STAGE_S8_RATE_EVENT_SET(Integer.valueOf(9076), "STR_STAGE_S8_RATE_EVENT_SET"),
    /*  883 */
    STR_STAGE_S9_RATE_EVENT_SET(Integer.valueOf(9077), "STR_STAGE_S9_RATE_EVENT_SET"),
    /*  884 */
    STR_STAGE_S10_RATE_EVENT_SET(Integer.valueOf(9078), "STR_STAGE_S10_RATE_EVENT_SET"),
    /*  885 */
    STR_STAGE_S11_RATE_EVENT_SET(Integer.valueOf(9079), "STR_STAGE_S11_RATE_EVENT_SET"),
    /*  886 */
    STR_STAGE_S12_RATE_EVENT_SET(Integer.valueOf(9080), "STR_STAGE_S12_RATE_EVENT_SET"),
    /*  887 */
    STR_STAGE_S13_RATE_EVENT_SET(Integer.valueOf(9081), "STR_STAGE_S13_RATE_EVENT_SET"),
    /*  888 */
    STR_STAGE_S14_RATE_EVENT_SET(Integer.valueOf(9082), "STR_STAGE_S14_RATE_EVENT_SET"),
    /*  889 */
    STR_STAGE_S15_RATE_EVENT_SET(Integer.valueOf(9083), "STR_STAGE_S15_RATE_EVENT_SET"),
    /*  890 */
    STR_STAGE_S16_RATE_EVENT_SET(Integer.valueOf(9084), "STR_STAGE_S16_RATE_EVENT_SET"),
    /*  891 */
    STR_STAGE_S17_RATE_EVENT_SET(Integer.valueOf(9085), "STR_STAGE_S17_RATE_EVENT_SET"),
    /*  892 */
    STR_STAGE_S18_RATE_EVENT_SET(Integer.valueOf(9086), "STR_STAGE_S18_RATE_EVENT_SET"),
    /*  893 */
    STR_STAGE_S19_RATE_EVENT_SET(Integer.valueOf(9087), "STR_STAGE_S19_RATE_EVENT_SET"),
    /*  894 */
    STR_STAGE_S20_RATE_EVENT_SET(Integer.valueOf(9088), "STR_STAGE_S20_RATE_EVENT_SET"),
    /*  895 */
    STR_STAGE_S21_RATE_EVENT_SET(Integer.valueOf(9089), "STR_STAGE_S21_RATE_EVENT_SET"),
    /*  896 */
    STR_STAGE_S22_RATE_EVENT_SET(Integer.valueOf(9090), "STR_STAGE_S22_RATE_EVENT_SET"),
    /*  897 */
    STR_STAGE_S23_RATE_EVENT_SET(Integer.valueOf(9091), "STR_STAGE_S23_RATE_EVENT_SET"),
    /*  898 */
    STR_STAGE_S24_RATE_EVENT_SET(Integer.valueOf(9092), "STR_STAGE_S24_RATE_EVENT_SET"),
    /*      */
    /*  900 */
    STR_STAGE_S1_TIME_EVENT_SET(Integer.valueOf(9093), "STR_STAGE_S1_TIME_EVENT_SET"),
    /*  901 */
    STR_STAGE_S2_TIME_EVENT_SET(Integer.valueOf(9094), "STR_STAGE_S2_TIME_EVENT_SET"),
    /*  902 */
    STR_STAGE_S3_TIME_EVENT_SET(Integer.valueOf(9095), "STR_STAGE_S3_TIME_EVENT_SET"),
    /*  903 */
    STR_STAGE_S4_TIME_EVENT_SET(Integer.valueOf(9096), "STR_STAGE_S4_TIME_EVENT_SET"),
    /*  904 */
    STR_STAGE_S5_TIME_EVENT_SET(Integer.valueOf(9097), "STR_STAGE_S5_TIME_EVENT_SET"),
    /*  905 */
    STR_STAGE_S6_TIME_EVENT_SET(Integer.valueOf(9098), "STR_STAGE_S6_TIME_EVENT_SET"),
    /*  906 */
    STR_STAGE_S7_TIME_EVENT_SET(Integer.valueOf(9099), "STR_STAGE_S7_TIME_EVENT_SET"),
    /*  907 */
    STR_STAGE_S8_TIME_EVENT_SET(Integer.valueOf(9100), "STR_STAGE_S8_TIME_EVENT_SET"),
    /*  908 */
    STR_STAGE_S9_TIME_EVENT_SET(Integer.valueOf(9101), "STR_STAGE_S9_TIME_EVENT_SET"),
    /*  909 */
    STR_STAGE_S10_TIME_EVENT_SET(Integer.valueOf(9102), "STR_STAGE_S10_TIME_EVENT_SET"),
    /*  910 */
    STR_STAGE_S11_TIME_EVENT_SET(Integer.valueOf(9103), "STR_STAGE_S11_TIME_EVENT_SET"),
    /*  911 */
    STR_STAGE_S12_TIME_EVENT_SET(Integer.valueOf(9104), "STR_STAGE_S12_TIME_EVENT_SET"),
    /*  912 */
    STR_STAGE_S13_TIME_EVENT_SET(Integer.valueOf(9105), "STR_STAGE_S13_TIME_EVENT_SET"),
    /*  913 */
    STR_STAGE_S14_TIME_EVENT_SET(Integer.valueOf(9106), "STR_STAGE_S14_TIME_EVENT_SET"),
    /*  914 */
    STR_STAGE_S15_TIME_EVENT_SET(Integer.valueOf(9107), "STR_STAGE_S15_TIME_EVENT_SET"),
    /*  915 */
    STR_STAGE_S16_TIME_EVENT_SET(Integer.valueOf(9108), "STR_STAGE_S16_TIME_EVENT_SET"),
    /*  916 */
    STR_STAGE_S17_TIME_EVENT_SET(Integer.valueOf(9109), "STR_STAGE_S17_TIME_EVENT_SET"),
    /*  917 */
    STR_STAGE_S18_TIME_EVENT_SET(Integer.valueOf(9110), "STR_STAGE_S18_TIME_EVENT_SET"),
    /*  918 */
    STR_STAGE_S19_TIME_EVENT_SET(Integer.valueOf(9111), "STR_STAGE_S19_TIME_EVENT_SET"),
    /*  919 */
    STR_STAGE_S20_TIME_EVENT_SET(Integer.valueOf(9112), "STR_STAGE_S20_TIME_EVENT_SET"),
    /*  920 */
    STR_STAGE_S21_TIME_EVENT_SET(Integer.valueOf(9113), "STR_STAGE_S21_TIME_EVENT_SET"),
    /*  921 */
    STR_STAGE_S22_TIME_EVENT_SET(Integer.valueOf(9114), "STR_STAGE_S22_TIME_EVENT_SET"),
    /*  922 */
    STR_STAGE_S23_TIME_EVENT_SET(Integer.valueOf(9115), "STR_STAGE_S23_TIME_EVENT_SET"),
    /*  923 */
    STR_STAGE_S24_TIME_EVENT_SET(Integer.valueOf(9116), "STR_STAGE_S24_TIME_EVENT_SET"),
    /*      */
    /*  925 */
    SEQUE_S1_VTBI(Integer.valueOf(9117), "SEQUE_S1_VTBI"),
    /*  926 */
    SEQUE_S2_VTBI(Integer.valueOf(9118), "SEQUE_S2_VTBI"),
    /*  927 */
    SEQUE_S3_VTBI(Integer.valueOf(9119), "SEQUE_S3_VTBI"),
    /*  928 */
    SEQUE_S4_VTBI(Integer.valueOf(9120), "SEQUE_S4_VTBI"),
    /*  929 */
    SEQUE_S5_VTBI(Integer.valueOf(9121), "SEQUE_S5_VTBI"),
    /*  930 */
    SEQUE_S6_VTBI(Integer.valueOf(9122), "SEQUE_S6_VTBI"),
    /*  931 */
    SEQUE_S7_VTBI(Integer.valueOf(9123), "SEQUE_S7_VTBI"),
    /*  932 */
    SEQUE_S8_VTBI(Integer.valueOf(9124), "SEQUE_S8_VTBI"),
    /*  933 */
    SEQUE_S9_VTBI(Integer.valueOf(9125), "SEQUE_S9_VTBI"),
    /*  934 */
    SEQUE_S10_VTBI(Integer.valueOf(9126), "SEQUE_S10_VTBI"),
    /*      */
    /*  936 */
    SEQUE_RATE_S1_RATE(Integer.valueOf(9127), "SEQUE_RATE_S1_RATE"),
    /*  937 */
    SEQUE_RATE_S2_RATE(Integer.valueOf(9128), "SEQUE_RATE_S2_RATE"),
    /*  938 */
    SEQUE_RATE_S3_RATE(Integer.valueOf(9129), "SEQUE_RATE_S3_RATE"),
    /*  939 */
    SEQUE_RATE_S4_RATE(Integer.valueOf(9130), "SEQUE_RATE_S4_RATE"),
    /*  940 */
    SEQUE_RATE_S5_RATE(Integer.valueOf(9131), "SEQUE_RATE_S5_RATE"),
    /*  941 */
    SEQUE_RATE_S6_RATE(Integer.valueOf(9132), "SEQUE_RATE_S6_RATE"),
    /*  942 */
    SEQUE_RATE_S7_RATE(Integer.valueOf(9133), "SEQUE_RATE_S7_RATE"),
    /*  943 */
    SEQUE_RATE_S8_RATE(Integer.valueOf(9134), "SEQUE_RATE_S8_RATE"),
    /*  944 */
    SEQUE_RATE_S9_RATE(Integer.valueOf(9135), "SEQUE_RATE_S9_RATE"),
    /*  945 */
    SEQUE_RATE_S10_RATE(Integer.valueOf(9136), "SEQUE_RATE_S10_RATE"),
    /*      */
    /*  947 */
    SEQUE_S1_TIME(Integer.valueOf(9137), "SEQUE_S1_TIME"),
    /*  948 */
    SEQUE_S2_TIME(Integer.valueOf(9138), "SEQUE_S2_TIME"),
    /*  949 */
    SEQUE_S3_TIME(Integer.valueOf(9139), "SEQUE_S3_TIME"),
    /*  950 */
    SEQUE_S4_TIME(Integer.valueOf(9140), "SEQUE_S4_TIME"),
    /*  951 */
    SEQUE_S5_TIME(Integer.valueOf(9141), "SEQUE_S5_TIME"),
    /*  952 */
    SEQUE_S6_TIME(Integer.valueOf(9142), "SEQUE_S6_TIME"),
    /*  953 */
    SEQUE_S7_TIME(Integer.valueOf(9143), "SEQUE_S7_TIME"),
    /*  954 */
    SEQUE_S8_TIME(Integer.valueOf(9144), "SEQUE_S8_TIME"),
    /*  955 */
    SEQUE_S9_TIME(Integer.valueOf(9145), "SEQUE_S9_TIME"),
    /*  956 */
    SEQUE_S10_TIME(Integer.valueOf(9146), "SEQUE_S10_TIME"),
    /*      */
    /*  958 */
    STR_SWITCH_DOSE_LMT_1H(Integer.valueOf(9147), "STR_SWITCH_DOSE_LMT_1H"),
    /*  959 */
    STR_SWITCH_DOSE_LMT_2H(Integer.valueOf(9148), "STR_SWITCH_DOSE_LMT_2H"),
    /*  960 */
    STR_SWITCH_DOSE_LMT_3H(Integer.valueOf(9149), "STR_SWITCH_DOSE_LMT_3H"),
    /*  961 */
    STR_SWITCH_DOSE_LMT_4H(Integer.valueOf(9150), "STR_SWITCH_DOSE_LMT_4H"),
    /*  962 */
    STR_SWITCH_DOSE_LMT_5H(Integer.valueOf(9151), "STR_SWITCH_DOSE_LMT_5H"),
    /*  963 */
    STR_SWITCH_DOSE_LMT_6H(Integer.valueOf(9152), "STR_SWITCH_DOSE_LMT_6H"),
    /*  964 */
    STR_SWITCH_DOSE_LMT_7H(Integer.valueOf(9153), "STR_SWITCH_DOSE_LMT_7H"),
    /*  965 */
    STR_SWITCH_DOSE_LMT_8H(Integer.valueOf(9154), "STR_SWITCH_DOSE_LMT_8H"),
    /*  966 */
    STR_SWITCH_DOSE_LMT_9H(Integer.valueOf(9155), "STR_SWITCH_DOSE_LMT_9H"),
    /*  967 */
    STR_SWITCH_DOSE_LMT_10H(Integer.valueOf(9156), "STR_SWITCH_DOSE_LMT_10H"),
    /*  968 */
    STR_SWITCH_DOSE_LMT_11H(Integer.valueOf(9157), "STR_SWITCH_DOSE_LMT_11H"),
    /*  969 */
    STR_SWITCH_DOSE_LMT_12H(Integer.valueOf(9158), "STR_SWITCH_DOSE_LMT_12H"),
    /*  970 */
    STR_SWITCH_DOSE_LMT_13H(Integer.valueOf(9159), "STR_SWITCH_DOSE_LMT_13H"),
    /*  971 */
    STR_SWITCH_DOSE_LMT_14H(Integer.valueOf(9160), "STR_SWITCH_DOSE_LMT_14H"),
    /*  972 */
    STR_SWITCH_DOSE_LMT_15H(Integer.valueOf(9161), "STR_SWITCH_DOSE_LMT_15H"),
    /*  973 */
    STR_SWITCH_DOSE_LMT_16H(Integer.valueOf(9162), "STR_SWITCH_DOSE_LMT_16H"),
    /*  974 */
    STR_SWITCH_DOSE_LMT_17H(Integer.valueOf(9163), "STR_SWITCH_DOSE_LMT_17H"),
    /*  975 */
    STR_SWITCH_DOSE_LMT_18H(Integer.valueOf(9164), "STR_SWITCH_DOSE_LMT_18H"),
    /*  976 */
    STR_SWITCH_DOSE_LMT_19H(Integer.valueOf(9165), "STR_SWITCH_DOSE_LMT_19H"),
    /*  977 */
    STR_SWITCH_DOSE_LMT_20H(Integer.valueOf(9166), "STR_SWITCH_DOSE_LMT_20H"),
    /*  978 */
    STR_SWITCH_DOSE_LMT_21H(Integer.valueOf(9167), "STR_SWITCH_DOSE_LMT_21H"),
    /*  979 */
    STR_SWITCH_DOSE_LMT_22H(Integer.valueOf(9168), "STR_SWITCH_DOSE_LMT_22H"),
    /*  980 */
    STR_SWITCH_DOSE_LMT_23H(Integer.valueOf(9169), "STR_SWITCH_DOSE_LMT_23H"),
    /*  981 */
    STR_SWITCH_DOSE_LMT_24H(Integer.valueOf(9170), "STR_SWITCH_DOSE_LMT_24H"),
    /*      */
    /*  983 */
    STR_DOSE_LIMIT_1H(Integer.valueOf(9171), "STR_DOSE_LIMIT_1H"),
    /*  984 */
    STR_DOSE_LIMIT_2H(Integer.valueOf(9172), "STR_DOSE_LIMIT_2H"),
    /*  985 */
    STR_DOSE_LIMIT_3H(Integer.valueOf(9173), "STR_DOSE_LIMIT_3H"),
    /*  986 */
    STR_DOSE_LIMIT_4H(Integer.valueOf(9174), "STR_DOSE_LIMIT_4H"),
    /*  987 */
    STR_DOSE_LIMIT_5H(Integer.valueOf(9175), "STR_DOSE_LIMIT_5H"),
    /*  988 */
    STR_DOSE_LIMIT_6H(Integer.valueOf(9176), "STR_DOSE_LIMIT_6H"),
    /*  989 */
    STR_DOSE_LIMIT_7H(Integer.valueOf(9177), "STR_DOSE_LIMIT_7H"),
    /*  990 */
    STR_DOSE_LIMIT_8H(Integer.valueOf(9178), "STR_DOSE_LIMIT_8H"),
    /*  991 */
    STR_DOSE_LIMIT_9H(Integer.valueOf(9179), "STR_DOSE_LIMIT_9H"),
    /*  992 */
    STR_DOSE_LIMIT_10H(Integer.valueOf(9180), "STR_DOSE_LIMIT_10H"),
    /*  993 */
    STR_DOSE_LIMIT_11H(Integer.valueOf(9181), "STR_DOSE_LIMIT_11H"),
    /*  994 */
    STR_DOSE_LIMIT_12H(Integer.valueOf(9182), "STR_DOSE_LIMIT_12H"),
    /*  995 */
    STR_DOSE_LIMIT_13H(Integer.valueOf(9183), "STR_DOSE_LIMIT_13H"),
    /*  996 */
    STR_DOSE_LIMIT_14H(Integer.valueOf(9184), "STR_DOSE_LIMIT_14H"),
    /*  997 */
    STR_DOSE_LIMIT_15H(Integer.valueOf(9185), "STR_DOSE_LIMIT_15H"),
    /*  998 */
    STR_DOSE_LIMIT_16H(Integer.valueOf(9186), "STR_DOSE_LIMIT_16H"),
    /*  999 */
    STR_DOSE_LIMIT_17H(Integer.valueOf(9187), "STR_DOSE_LIMIT_17H"),
    /* 1000 */
    STR_DOSE_LIMIT_18H(Integer.valueOf(9188), "STR_DOSE_LIMIT_18H"),
    /* 1001 */
    STR_DOSE_LIMIT_19H(Integer.valueOf(9189), "STR_DOSE_LIMIT_19H"),
    /* 1002 */
    STR_DOSE_LIMIT_20H(Integer.valueOf(9190), "STR_DOSE_LIMIT_20H"),
    /* 1003 */
    STR_DOSE_LIMIT_21H(Integer.valueOf(9191), "STR_DOSE_LIMIT_21H"),
    /* 1004 */
    STR_DOSE_LIMIT_22H(Integer.valueOf(9192), "STR_DOSE_LIMIT_22H"),
    /* 1005 */
    STR_DOSE_LIMIT_23H(Integer.valueOf(9193), "STR_DOSE_LIMIT_23H"),
    /* 1006 */
    STR_DOSE_LIMIT_24H(Integer.valueOf(9194), "STR_DOSE_LIMIT_24H"),
    /*      */
    /* 1008 */
    LOAD_DOSE_SOFT_MIN_EXCEED(Integer.valueOf(9195), "LOAD_DOSE_SOFT_MIN_EXCEED"),
    /* 1009 */
    LOAD_DOSE_SOFT_MAX_EXCEED(Integer.valueOf(9196), "LOAD_DOSE_SOFT_MAX_EXCEED"),
    /* 1010 */
    LOAD_DOSE_HARD_MIN_EXCEED(Integer.valueOf(9197), "LOAD_DOSE_HARD_MIN_EXCEED"),
    /*      */
    /* 1012 */
    CONT_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9199), "CONT_RATE_SOFT_MIN_EXCEED"),
    /* 1013 */
    CONT_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9200), "CONT_RATE_SOFT_MAX_EXCEED"),
    /* 1014 */
    CONT_RATE_HARD_MIN_EXCEED(Integer.valueOf(9201), "CONT_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1016 */
    PCA_DOSE_SOFT_MIN_EXCEED(Integer.valueOf(9203), "PCA_DOSE_SOFT_MIN_EXCEED"),
    /* 1017 */
    PCA_DOSE_SOFT_MAX_EXCEED(Integer.valueOf(9204), "PCA_DOSE_SOFT_MAX_EXCEED"),
    /* 1018 */
    PCA_DOSE_HARD_MIN_EXCEED(Integer.valueOf(9205), "PCA_DOSE_HARD_MIN_EXCEED"),
    /*      */
    /* 1020 */
    LOCK_TIME_SOFT_MIN_EXCEED(Integer.valueOf(9207), "LOCK_TIME_SOFT_MIN_EXCEED"),
    /* 1021 */
    LOCK_TIME_SOFT_MAX_EXCEED(Integer.valueOf(9208), "LOCK_TIME_SOFT_MAX_EXCEED"),
    /* 1022 */
    LOCK_TIME_HARD_MIN_EXCEED(Integer.valueOf(9209), "LOCK_TIME_HARD_MIN_EXCEED"),
    /*      */
    /* 1024 */
    LMT_DOSE_SOFT_MIN_EXCEED_1H(Integer.valueOf(9211), "LMT_DOSE_SOFT_MIN_EXCEED_1H"),
    /* 1025 */
    LMT_DOSE_SOFT_MAX_EXCEED_1H(Integer.valueOf(9212), "LMT_DOSE_SOFT_MAX_EXCEED_1H"),
    /* 1026 */
    LMT_DOSE_HARD_MIN_EXCEED_1H(Integer.valueOf(9213), "LMT_DOSE_HARD_MIN_EXCEED_1H"),
    /*      */
    /* 1028 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_1H(Integer.valueOf(9215), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_1H"),
    /* 1029 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_1H(Integer.valueOf(9216), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_1H"),
    /* 1030 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_1H(Integer.valueOf(9217), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_1H"),
    /*      */
    /* 1032 */
    START_TIME_SOFT_MIN_EXCEED(Integer.valueOf(9219), "START_TIME_SOFT_MIN_EXCEED"),
    /* 1033 */
    START_TIME_SOFT_MAX_EXCEED(Integer.valueOf(9220), "START_TIME_SOFT_MAX_EXCEED"),
    /* 1034 */
    START_TIME_HARD_MIN_EXCEED(Integer.valueOf(9221), "START_TIME_HARD_MIN_EXCEED"),
    /*      */
    /* 1036 */
    PIEB_MODE_SOFT_MIN_EXCEED(Integer.valueOf(9223), "PIEB_MODE_SOFT_MIN_EXCEED"),
    /* 1037 */
    PIEB_MODE_SOFT_MAX_EXCEED(Integer.valueOf(9224), "PIEB_MODE_SOFT_MAX_EXCEED"),
    /* 1038 */
    PIEB_MODE_HARD_MIN_EXCEED(Integer.valueOf(9225), "PIEB_MODE_HARD_MIN_EXCEED"),
    /*      */
    /* 1040 */
    PIEB_INTER_TIME_SOFT_MIN_EXCEED(Integer.valueOf(9227), "PIEB_INTER_TIME_SOFT_MIN_EXCEED"),
    /* 1041 */
    PIEB_INTER_TIME_SOFT_MAX_EXCEED(Integer.valueOf(9228), "PIEB_INTER_TIME_SOFT_MAX_EXCEED"),
    /* 1042 */
    PIEB_INTER_TIME_HARD_MIN_EXCEED(Integer.valueOf(9229), "PIEB_INTER_TIME_HARD_MIN_EXCEED"),
    /*      */
    /* 1044 */
    DOSE_SOFT_MIN_EXCEED(Integer.valueOf(9231), "DOSE_SOFT_MIN_EXCEED"),
    /* 1045 */
    DOSE_SOFT_MAX_EXCEED(Integer.valueOf(9232), "DOSE_SOFT_MAX_EXCEED"),
    /* 1046 */
    DOSE_HARD_MIN_EXCEED(Integer.valueOf(9233), "DOSE_HARD_MIN_EXCEED"),
    /*      */
    /* 1048 */
    LOAD_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9235), "LOAD_RATE_SOFT_MIN_EXCEED"),
    /* 1049 */
    LOAD_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9236), "LOAD_RATE_SOFT_MAX_EXCEED"),
    /* 1050 */
    LOAD_RATE_HARD_MIN_EXCEED(Integer.valueOf(9237), "LOAD_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1052 */
    LOAD_CONT_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9239), "LOAD_CONT_RATE_SOFT_MIN_EXCEED"),
    /* 1053 */
    LOAD_CONT_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9240), "LOAD_CONT_RATE_SOFT_MAX_EXCEED"),
    /* 1054 */
    LOAD_CONT_RATE_HARD_MIN_EXCEED(Integer.valueOf(9241), "LOAD_CONT_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1056 */
    INTER_MODE_VOL_SOFT_MIN_EXCEED(Integer.valueOf(9243), "INTER_MODE_VOL_SOFT_MIN_EXCEED"),
    /* 1057 */
    INTER_MODE_VOL_SOFT_MAX_EXCEED(Integer.valueOf(9244), "INTER_MODE_VOL_SOFT_MAX_EXCEED"),
    /* 1058 */
    INTER_MODE_VOL_HARD_MIN_EXCEED(Integer.valueOf(9245), "INTER_MODE_VOL_HARD_MIN_EXCEED"),
    /*      */
    /* 1060 */
    INTER_MODE_DOSE_SOFT_MIN_EXCEED(Integer.valueOf(9247), "INTER_MODE_DOSE_SOFT_MIN_EXCEED"),
    /* 1061 */
    INTER_MODE_DOSE_SOFT_MAX_EXCEED(Integer.valueOf(9248), "INTER_MODE_DOSE_SOFT_MAX_EXCEED"),
    /* 1062 */
    INTER_MODE_DOSE_HARD_MIN_EXCEED(Integer.valueOf(9249), "INTER_MODE_DOSE_HARD_MIN_EXCEED"),
    /*      */
    /* 1064 */
    INTER_MODE_TIME_SOFT_MIN_EXCEED(Integer.valueOf(9251), "INTER_MODE_TIME_SOFT_MIN_EXCEED"),
    /* 1065 */
    INTER_MODE_TIME_SOFT_MAX_EXCEED(Integer.valueOf(9252), "INTER_MODE_TIME_SOFT_MAX_EXCEED"),
    /* 1066 */
    INTER_MODE_TIME_HARD_MIN_EXCEED(Integer.valueOf(9253), "INTER_MODE_TIME_HARD_MIN_EXCEED"),
    /*      */
    /* 1068 */
    INTER_MODE_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9255), "INTER_MODE_RATE_SOFT_MIN_EXCEED"),
    /* 1069 */
    INTER_MODE_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9256), "INTER_MODE_RATE_SOFT_MAX_EXCEED"),
    /* 1070 */
    INTER_MODE_RATE_HARD_MIN_EXCEED(Integer.valueOf(9257), "INTER_MODE_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1072 */
    INTER_MODE_DOSE_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9259), "INTER_MODE_DOSE_RATE_SOFT_MIN_EXCEED"),
    /* 1073 */
    INTER_MODE_DOSE_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9260), "INTER_MODE_DOSE_RATE_SOFT_MAX_EXCEED"),
    /* 1074 */
    INTER_MODE_DOSE_RATE_HARD_MIN_EXCEED(Integer.valueOf(9261), "INTER_MODE_DOSE_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1076 */
    UP_TIME_SOFT_MIN_EXCEED(Integer.valueOf(9263), "UP_TIME_SOFT_MIN_EXCEED"),
    /* 1077 */
    UP_TIME_SOFT_MAX_EXCEED(Integer.valueOf(9264), "UP_TIME_SOFT_MAX_EXCEED"),
    /* 1078 */
    UP_TIME_HARD_MIN_EXCEED(Integer.valueOf(9265), "UP_TIME_HARD_MIN_EXCEED"),
    /*      */
    /* 1080 */
    DOWN_TIME_SOFT_MIN_EXCEED(Integer.valueOf(9267), "DOWN_TIME_SOFT_MIN_EXCEED"),
    /* 1081 */
    DOWN_TIME_SOFT_MAX_EXCEED(Integer.valueOf(9268), "DOWN_TIME_SOFT_MAX_EXCEED"),
    /* 1082 */
    DOWN_TIME_HARD_MIN_EXCEED(Integer.valueOf(9269), "DOWN_TIME_HARD_MIN_EXCEED"),
    /*      */
    /* 1084 */
    STABLE_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9271), "STABLE_RATE_SOFT_MIN_EXCEED"),
    /* 1085 */
    STABLE_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9272), "STABLE_RATE_SOFT_MAX_EXCEED"),
    /* 1086 */
    STABLE_RATE_HARD_MIN_EXCEED(Integer.valueOf(9273), "STABLE_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1088 */
    RATE_MODE_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9275), "RATE_MODE_RATE_SOFT_MIN_EXCEED"),
    /* 1089 */
    RATE_MODE_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9276), "RATE_MODE_RATE_SOFT_MAX_EXCEED"),
    /* 1090 */
    RATE_MODE_RATE_HARD_MIN_EXCEED(Integer.valueOf(9277), "RATE_MODE_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1092 */
    CHRO_SEQ_S1_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9279), "CHRO_SEQ_S1_RATE_SOFT_MIN_EXCEED"),
    /* 1093 */
    CHRO_SEQ_S1_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9280), "CHRO_SEQ_S1_RATE_SOFT_MAX_EXCEED"),
    /* 1094 */
    CHRO_SEQ_S1_RATE_HARD_MIN_EXCEED(Integer.valueOf(9281), "CHRO_SEQ_S1_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1096 */
    CHRO_SEQ_S2_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9283), "CHRO_SEQ_S2_RATE_SOFT_MIN_EXCEED"),
    /* 1097 */
    CHRO_SEQ_S2_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9284), "CHRO_SEQ_S2_RATE_SOFT_MAX_EXCEED"),
    /* 1098 */
    CHRO_SEQ_S2_RATE_HARD_MIN_EXCEED(Integer.valueOf(9285), "CHRO_SEQ_S2_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1100 */
    CHRO_SEQ_S3_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9287), "CHRO_SEQ_S3_RATE_SOFT_MIN_EXCEED"),
    /* 1101 */
    CHRO_SEQ_S3_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9288), "CHRO_SEQ_S3_RATE_SOFT_MAX_EXCEED"),
    /* 1102 */
    CHRO_SEQ_S3_RATE_HARD_MIN_EXCEED(Integer.valueOf(9289), "CHRO_SEQ_S3_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1104 */
    CHRO_SEQ_S4_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9291), "CHRO_SEQ_S4_RATE_SOFT_MIN_EXCEED"),
    /* 1105 */
    CHRO_SEQ_S4_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9292), "CHRO_SEQ_S4_RATE_SOFT_MAX_EXCEED"),
    /* 1106 */
    CHRO_SEQ_S4_RATE_HARD_MIN_EXCEED(Integer.valueOf(9293), "CHRO_SEQ_S4_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1108 */
    CHRO_SEQ_S5_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9295), "CHRO_SEQ_S5_RATE_SOFT_MIN_EXCEED"),
    /* 1109 */
    CHRO_SEQ_S5_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9296), "CHRO_SEQ_S5_RATE_SOFT_MAX_EXCEED"),
    /* 1110 */
    CHRO_SEQ_S5_RATE_HARD_MIN_EXCEED(Integer.valueOf(9297), "CHRO_SEQ_S5_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1112 */
    CHRO_SEQ_S6_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9299), "CHRO_SEQ_S6_RATE_SOFT_MIN_EXCEED"),
    /* 1113 */
    CHRO_SEQ_S6_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9300), "CHRO_SEQ_S6_RATE_SOFT_MAX_EXCEED"),
    /* 1114 */
    CHRO_SEQ_S6_RATE_HARD_MIN_EXCEED(Integer.valueOf(9301), "CHRO_SEQ_S6_RATE_HARD_MIN_EXCEED"),
    /* 1115 */
    CHRO_SEQ_S7_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9303), "CHRO_SEQ_S7_RATE_SOFT_MIN_EXCEED"),
    /* 1116 */
    CHRO_SEQ_S7_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9304), "CHRO_SEQ_S7_RATE_SOFT_MAX_EXCEED"),
    /* 1117 */
    CHRO_SEQ_S7_RATE_HARD_MIN_EXCEED(Integer.valueOf(9305), "CHRO_SEQ_S7_RATE_HARD_MIN_EXCEED"),
    /* 1118 */
    CHRO_SEQ_S8_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9307), "CHRO_SEQ_S8_RATE_SOFT_MIN_EXCEED"),
    /* 1119 */
    CHRO_SEQ_S8_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9308), "CHRO_SEQ_S8_RATE_SOFT_MAX_EXCEED"),
    /* 1120 */
    CHRO_SEQ_S8_RATE_HARD_MIN_EXCEED(Integer.valueOf(9309), "CHRO_SEQ_S8_RATE_HARD_MIN_EXCEED"),
    /* 1121 */
    CHRO_SEQ_S9_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9311), "CHRO_SEQ_S9_RATE_SOFT_MIN_EXCEED"),
    /* 1122 */
    CHRO_SEQ_S9_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9312), "CHRO_SEQ_S9_RATE_SOFT_MAX_EXCEED"),
    /* 1123 */
    CHRO_SEQ_S9_RATE_HARD_MIN_EXCEED(Integer.valueOf(9313), "CHRO_SEQ_S9_RATE_HARD_MIN_EXCEED"),
    /* 1124 */
    CHRO_SEQ_S10_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9315), "CHRO_SEQ_S10_RATE_SOFT_MIN_EXCEED"),
    /* 1125 */
    CHRO_SEQ_S10_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9316), "CHRO_SEQ_S10_RATE_SOFT_MAX_EXCEED"),
    /* 1126 */
    CHRO_SEQ_S10_RATE_HARD_MIN_EXCEED(Integer.valueOf(9317), "CHRO_SEQ_S10_RATE_HARD_MIN_EXCEED"),
    /* 1127 */
    CHRO_SEQ_S11_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9319), "CHRO_SEQ_S11_RATE_SOFT_MIN_EXCEED"),
    /* 1128 */
    CHRO_SEQ_S11_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9320), "CHRO_SEQ_S11_RATE_SOFT_MAX_EXCEED"),
    /* 1129 */
    CHRO_SEQ_S11_RATE_HARD_MIN_EXCEED(Integer.valueOf(9321), "CHRO_SEQ_S11_RATE_HARD_MIN_EXCEED"),
    /* 1130 */
    CHRO_SEQ_S12_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9323), "CHRO_SEQ_S12_RATE_SOFT_MIN_EXCEED"),
    /* 1131 */
    CHRO_SEQ_S12_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9324), "CHRO_SEQ_S12_RATE_SOFT_MAX_EXCEED"),
    /* 1132 */
    CHRO_SEQ_S12_RATE_HARD_MIN_EXCEED(Integer.valueOf(9325), "CHRO_SEQ_S12_RATE_HARD_MIN_EXCEED"),
    /* 1133 */
    CHRO_SEQ_S13_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9327), "CHRO_SEQ_S13_RATE_SOFT_MIN_EXCEED"),
    /* 1134 */
    CHRO_SEQ_S13_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9328), "CHRO_SEQ_S13_RATE_SOFT_MAX_EXCEED"),
    /* 1135 */
    CHRO_SEQ_S13_RATE_HARD_MIN_EXCEED(Integer.valueOf(9329), "CHRO_SEQ_S13_RATE_HARD_MIN_EXCEED"),
    /* 1136 */
    CHRO_SEQ_S14_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9331), "CHRO_SEQ_S14_RATE_SOFT_MIN_EXCEED"),
    /* 1137 */
    CHRO_SEQ_S14_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9332), "CHRO_SEQ_S14_RATE_SOFT_MAX_EXCEED"),
    /* 1138 */
    CHRO_SEQ_S14_RATE_HARD_MIN_EXCEED(Integer.valueOf(9333), "CHRO_SEQ_S14_RATE_HARD_MIN_EXCEED"),
    /* 1139 */
    CHRO_SEQ_S15_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9335), "CHRO_SEQ_S15_RATE_SOFT_MIN_EXCEED"),
    /* 1140 */
    CHRO_SEQ_S15_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9336), "CHRO_SEQ_S15_RATE_SOFT_MAX_EXCEED"),
    /* 1141 */
    CHRO_SEQ_S15_RATE_HARD_MIN_EXCEED(Integer.valueOf(9337), "CHRO_SEQ_S15_RATE_HARD_MIN_EXCEED"),
    /* 1142 */
    CHRO_SEQ_S16_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9339), "CHRO_SEQ_S16_RATE_SOFT_MIN_EXCEED"),
    /* 1143 */
    CHRO_SEQ_S16_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9340), "CHRO_SEQ_S16_RATE_SOFT_MAX_EXCEED"),
    /* 1144 */
    CHRO_SEQ_S16_RATE_HARD_MIN_EXCEED(Integer.valueOf(9341), "CHRO_SEQ_S16_RATE_HARD_MIN_EXCEED"),
    /* 1145 */
    CHRO_SEQ_S17_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9343), "CHRO_SEQ_S17_RATE_SOFT_MIN_EXCEED"),
    /* 1146 */
    CHRO_SEQ_S17_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9344), "CHRO_SEQ_S17_RATE_SOFT_MAX_EXCEED"),
    /* 1147 */
    CHRO_SEQ_S17_RATE_HARD_MIN_EXCEED(Integer.valueOf(9345), "CHRO_SEQ_S17_RATE_HARD_MIN_EXCEED"),
    /* 1148 */
    CHRO_SEQ_S18_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9347), "CHRO_SEQ_S18_RATE_SOFT_MIN_EXCEED"),
    /* 1149 */
    CHRO_SEQ_S18_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9348), "CHRO_SEQ_S18_RATE_SOFT_MAX_EXCEED"),
    /* 1150 */
    CHRO_SEQ_S18_RATE_HARD_MIN_EXCEED(Integer.valueOf(9349), "CHRO_SEQ_S18_RATE_HARD_MIN_EXCEED"),
    /* 1151 */
    CHRO_SEQ_S19_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9351), "CHRO_SEQ_S19_RATE_SOFT_MIN_EXCEED"),
    /* 1152 */
    CHRO_SEQ_S19_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9352), "CHRO_SEQ_S19_RATE_SOFT_MAX_EXCEED"),
    /* 1153 */
    CHRO_SEQ_S19_RATE_HARD_MIN_EXCEED(Integer.valueOf(9353), "CHRO_SEQ_S19_RATE_HARD_MIN_EXCEED"),
    /* 1154 */
    CHRO_SEQ_S20_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9355), "CHRO_SEQ_S20_RATE_SOFT_MIN_EXCEED"),
    /* 1155 */
    CHRO_SEQ_S20_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9356), "CHRO_SEQ_S20_RATE_SOFT_MAX_EXCEED"),
    /* 1156 */
    CHRO_SEQ_S20_RATE_HARD_MIN_EXCEED(Integer.valueOf(9357), "CHRO_SEQ_S20_RATE_HARD_MIN_EXCEED"),
    /* 1157 */
    CHRO_SEQ_S21_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9359), "CHRO_SEQ_S21_RATE_SOFT_MIN_EXCEED"),
    /* 1158 */
    CHRO_SEQ_S21_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9360), "CHRO_SEQ_S21_RATE_SOFT_MAX_EXCEED"),
    /* 1159 */
    CHRO_SEQ_S21_RATE_HARD_MIN_EXCEED(Integer.valueOf(9361), "CHRO_SEQ_S21_RATE_HARD_MIN_EXCEED"),
    /* 1160 */
    CHRO_SEQ_S22_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9363), "CHRO_SEQ_S22_RATE_SOFT_MIN_EXCEED"),
    /* 1161 */
    CHRO_SEQ_S22_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9364), "CHRO_SEQ_S22_RATE_SOFT_MAX_EXCEED"),
    /* 1162 */
    CHRO_SEQ_S22_RATE_HARD_MIN_EXCEED(Integer.valueOf(9365), "CHRO_SEQ_S22_RATE_HARD_MIN_EXCEED"),
    /* 1163 */
    CHRO_SEQ_S23_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9367), "CHRO_SEQ_S23_RATE_SOFT_MIN_EXCEED"),
    /* 1164 */
    CHRO_SEQ_S23_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9368), "CHRO_SEQ_S23_RATE_SOFT_MAX_EXCEED"),
    /* 1165 */
    CHRO_SEQ_S23_RATE_HARD_MIN_EXCEED(Integer.valueOf(9369), "CHRO_SEQ_S23_RATE_HARD_MIN_EXCEED"),
    /* 1166 */
    CHRO_SEQ_S24_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9371), "CHRO_SEQ_S24_RATE_SOFT_MIN_EXCEED"),
    /* 1167 */
    CHRO_SEQ_S24_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9372), "CHRO_SEQ_S24_RATE_SOFT_MAX_EXCEED"),
    /* 1168 */
    CHRO_SEQ_S24_RATE_HARD_MIN_EXCEED(Integer.valueOf(9373), "CHRO_SEQ_S24_RATE_HARD_MIN_EXCEED"),
    /* 1169 */
    SEQUE_RATE_S1_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9375), "SEQUE_RATE_S1_RATE_SOFT_MIN_EXCEED"),
    /* 1170 */
    SEQUE_RATE_S1_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9376), "SEQUE_RATE_S1_RATE_SOFT_MAX_EXCEED"),
    /* 1171 */
    SEQUE_RATE_S1_RATE_HARD_MIN_EXCEED(Integer.valueOf(9377), "SEQUE_RATE_S1_RATE_HARD_MIN_EXCEED"),
    /* 1172 */
    SEQUE_RATE_S2_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9379), "SEQUE_RATE_S2_RATE_SOFT_MIN_EXCEED"),
    /* 1173 */
    SEQUE_RATE_S2_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9380), "SEQUE_RATE_S2_RATE_SOFT_MAX_EXCEED"),
    /* 1174 */
    SEQUE_RATE_S2_RATE_HARD_MIN_EXCEED(Integer.valueOf(9381), "SEQUE_RATE_S2_RATE_HARD_MIN_EXCEED"),
    /* 1175 */
    SEQUE_RATE_S3_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9383), "SEQUE_RATE_S3_RATE_SOFT_MIN_EXCEED"),
    /* 1176 */
    SEQUE_RATE_S3_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9384), "SEQUE_RATE_S3_RATE_SOFT_MAX_EXCEED"),
    /* 1177 */
    SEQUE_RATE_S3_RATE_HARD_MIN_EXCEED(Integer.valueOf(9385), "SEQUE_RATE_S3_RATE_HARD_MIN_EXCEED"),
    /* 1178 */
    SEQUE_RATE_S4_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9387), "SEQUE_RATE_S4_RATE_SOFT_MIN_EXCEED"),
    /* 1179 */
    SEQUE_RATE_S4_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9388), "SEQUE_RATE_S4_RATE_SOFT_MAX_EXCEED"),
    /* 1180 */
    SEQUE_RATE_S4_RATE_HARD_MIN_EXCEED(Integer.valueOf(9389), "SEQUE_RATE_S4_RATE_HARD_MIN_EXCEED"),
    /* 1181 */
    SEQUE_RATE_S5_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9391), "SEQUE_RATE_S5_RATE_SOFT_MIN_EXCEED"),
    /* 1182 */
    SEQUE_RATE_S5_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9392), "SEQUE_RATE_S5_RATE_SOFT_MAX_EXCEED"),
    /* 1183 */
    SEQUE_RATE_S5_RATE_HARD_MIN_EXCEED(Integer.valueOf(9393), "SEQUE_RATE_S5_RATE_HARD_MIN_EXCEED"),
    /* 1184 */
    SEQUE_RATE_S6_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9395), "SEQUE_RATE_S6_RATE_SOFT_MIN_EXCEED"),
    /* 1185 */
    SEQUE_RATE_S6_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9396), "SEQUE_RATE_S6_RATE_SOFT_MAX_EXCEED"),
    /* 1186 */
    SEQUE_RATE_S6_RATE_HARD_MIN_EXCEED(Integer.valueOf(9397), "SEQUE_RATE_S6_RATE_HARD_MIN_EXCEED"),
    /* 1187 */
    SEQUE_RATE_S7_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9399), "SEQUE_RATE_S7_RATE_SOFT_MIN_EXCEED"),
    /* 1188 */
    SEQUE_RATE_S7_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9400), "SEQUE_RATE_S7_RATE_SOFT_MAX_EXCEED"),
    /* 1189 */
    SEQUE_RATE_S7_RATE_HARD_MIN_EXCEED(Integer.valueOf(9401), "SEQUE_RATE_S7_RATE_HARD_MIN_EXCEED"),
    /* 1190 */
    SEQUE_RATE_S8_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9403), "SEQUE_RATE_S8_RATE_SOFT_MIN_EXCEED"),
    /* 1191 */
    SEQUE_RATE_S8_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9404), "SEQUE_RATE_S8_RATE_SOFT_MAX_EXCEED"),
    /* 1192 */
    SEQUE_RATE_S8_RATE_HARD_MIN_EXCEED(Integer.valueOf(9405), "SEQUE_RATE_S8_RATE_HARD_MIN_EXCEED"),
    /* 1193 */
    SEQUE_RATE_S9_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9407), "SEQUE_RATE_S9_RATE_SOFT_MIN_EXCEED"),
    /* 1194 */
    SEQUE_RATE_S9_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9408), "SEQUE_RATE_S9_RATE_SOFT_MAX_EXCEED"),
    /* 1195 */
    SEQUE_RATE_S9_RATE_HARD_MIN_EXCEED(Integer.valueOf(9409), "SEQUE_RATE_S9_RATE_HARD_MIN_EXCEED"),
    /* 1196 */
    SEQUE_RATE_S10_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9411), "SEQUE_RATE_S10_RATE_SOFT_MIN_EXCEED"),
    /* 1197 */
    SEQUE_RATE_S10_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9412), "SEQUE_RATE_S10_RATE_SOFT_MAX_EXCEED"),
    /* 1198 */
    SEQUE_RATE_S10_RATE_HARD_MIN_EXCEED(Integer.valueOf(9413), "SEQUE_RATE_S10_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1200 */
    MODE_BOLUS_VTBI_SOFT_MIN_EXCEED(Integer.valueOf(9415), "MODE_BOLUS_VTBI_SOFT_MIN_EXCEED"),
    /* 1201 */
    MODE_BOLUS_VTBI_SOFT_MAX_EXCEED(Integer.valueOf(9416), "MODE_BOLUS_VTBI_SOFT_MAX_EXCEED"),
    /* 1202 */
    MODE_BOLUS_VTBI_HARD_MIN_EXCEED(Integer.valueOf(9417), "MODE_BOLUS_VTBI_HARD_MIN_EXCEED"),
    /* 1203 */
    MODE_BOLUS_DOSE_SOFT_MIN_EXCEED(Integer.valueOf(9419), "MODE_BOLUS_DOSE_SOFT_MIN_EXCEED"),
    /* 1204 */
    MODE_BOLUS_DOSE_SOFT_MAX_EXCEED(Integer.valueOf(9420), "MODE_BOLUS_DOSE_SOFT_MAX_EXCEED"),
    /* 1205 */
    MODE_BOLUS_DOSE_HARD_MIN_EXCEED(Integer.valueOf(9421), "MODE_BOLUS_DOSE_HARD_MIN_EXCEED"),
    /*      */
    /* 1207 */
    DOSE_MODE_PCA_DOSE_SOFT_MIN_EXCEED(Integer.valueOf(9423), "DOSE_MODE_PCA_DOSE_SOFT_MIN_EXCEED"),
    /* 1208 */
    DOSE_MODE_PCA_DOSE_SOFT_MAX_EXCEED(Integer.valueOf(9424), "DOSE_MODE_PCA_DOSE_SOFT_MAX_EXCEED"),
    /* 1209 */
    DOSE_MODE_PCA_DOSE_HARD_MIN_EXCEED(Integer.valueOf(9425), "DOSE_MODE_PCA_DOSE_HARD_MIN_EXCEED"),
    /*      */
    /* 1211 */
    DOSE_MODE_CONT_RATE_SOFT_MIN_EXCEED(Integer.valueOf(9427), "DOSE_MODE_CONT_RATE_SOFT_MIN_EXCEED"),
    /* 1212 */
    DOSE_MODE_CONT_RATE_SOFT_MAX_EXCEED(Integer.valueOf(9428), "DOSE_MODE_CONT_RATE_SOFT_MAX_EXCEED"),
    /* 1213 */
    DOSE_MODE_CONT_RATE_HARD_MIN_EXCEED(Integer.valueOf(9429), "DOSE_MODE_CONT_RATE_HARD_MIN_EXCEED"),
    /*      */
    /* 1215 */
    STR_STAGE_S1_RATE(Integer.valueOf(9431), "STR_STAGE_S1_RATE"),
    /* 1216 */
    STR_STAGE_S2_RATE(Integer.valueOf(9432), "STR_STAGE_S2_RATE"),
    /* 1217 */
    STR_STAGE_S3_RATE(Integer.valueOf(9433), "STR_STAGE_S3_RATE"),
    /* 1218 */
    STR_STAGE_S4_RATE(Integer.valueOf(9434), "STR_STAGE_S4_RATE"),
    /* 1219 */
    STR_STAGE_S5_RATE(Integer.valueOf(9435), "STR_STAGE_S5_RATE"),
    /* 1220 */
    STR_STAGE_S6_RATE(Integer.valueOf(9436), "STR_STAGE_S6_RATE"),
    /* 1221 */
    STR_STAGE_S7_RATE(Integer.valueOf(9437), "STR_STAGE_S7_RATE"),
    /* 1222 */
    STR_STAGE_S8_RATE(Integer.valueOf(9438), "STR_STAGE_S8_RATE"),
    /* 1223 */
    STR_STAGE_S9_RATE(Integer.valueOf(9439), "STR_STAGE_S9_RATE"),
    /* 1224 */
    STR_STAGE_S10_RATE(Integer.valueOf(9440), "STR_STAGE_S10_RATE"),
    /* 1225 */
    STR_STAGE_S11_RATE(Integer.valueOf(9441), "STR_STAGE_S11_RATE"),
    /* 1226 */
    STR_STAGE_S12_RATE(Integer.valueOf(9442), "STR_STAGE_S12_RATE"),
    /* 1227 */
    STR_STAGE_S13_RATE(Integer.valueOf(9443), "STR_STAGE_S13_RATE"),
    /* 1228 */
    STR_STAGE_S14_RATE(Integer.valueOf(9444), "STR_STAGE_S14_RATE"),
    /* 1229 */
    STR_STAGE_S15_RATE(Integer.valueOf(9445), "STR_STAGE_S15_RATE"),
    /* 1230 */
    STR_STAGE_S16_RATE(Integer.valueOf(9446), "STR_STAGE_S16_RATE"),
    /* 1231 */
    STR_STAGE_S17_RATE(Integer.valueOf(9447), "STR_STAGE_S17_RATE"),
    /* 1232 */
    STR_STAGE_S18_RATE(Integer.valueOf(9448), "STR_STAGE_S18_RATE"),
    /* 1233 */
    STR_STAGE_S19_RATE(Integer.valueOf(9449), "STR_STAGE_S19_RATE"),
    /* 1234 */
    STR_STAGE_S20_RATE(Integer.valueOf(9450), "STR_STAGE_S20_RATE"),
    /* 1235 */
    STR_STAGE_S21_RATE(Integer.valueOf(9451), "STR_STAGE_S21_RATE"),
    /* 1236 */
    STR_STAGE_S22_RATE(Integer.valueOf(9452), "STR_STAGE_S22_RATE"),
    /* 1237 */
    STR_STAGE_S23_RATE(Integer.valueOf(9453), "STR_STAGE_S23_RATE"),
    /* 1238 */
    STR_STAGE_S24_RATE(Integer.valueOf(9454), "STR_STAGE_S24_RATE"),
    /* 1239 */
    STR_STAGE_S1_TIME(Integer.valueOf(9455), "STR_STAGE_S1_TIME"),
    /* 1240 */
    STR_STAGE_S2_TIME(Integer.valueOf(9456), "STR_STAGE_S2_TIME"),
    /* 1241 */
    STR_STAGE_S3_TIME(Integer.valueOf(9457), "STR_STAGE_S3_TIME"),
    /* 1242 */
    STR_STAGE_S4_TIME(Integer.valueOf(9458), "STR_STAGE_S4_TIME"),
    /* 1243 */
    STR_STAGE_S5_TIME(Integer.valueOf(9459), "STR_STAGE_S5_TIME"),
    /* 1244 */
    STR_STAGE_S6_TIME(Integer.valueOf(9460), "STR_STAGE_S6_TIME"),
    /* 1245 */
    STR_STAGE_S7_TIME(Integer.valueOf(9461), "STR_STAGE_S7_TIME"),
    /* 1246 */
    STR_STAGE_S8_TIME(Integer.valueOf(9462), "STR_STAGE_S8_TIME"),
    /* 1247 */
    STR_STAGE_S9_TIME(Integer.valueOf(9463), "STR_STAGE_S9_TIME"),
    /* 1248 */
    STR_STAGE_S10_TIME(Integer.valueOf(9464), "STR_STAGE_S10_TIME"),
    /* 1249 */
    STR_STAGE_S11_TIME(Integer.valueOf(9465), "STR_STAGE_S11_TIME"),
    /* 1250 */
    STR_STAGE_S12_TIME(Integer.valueOf(9466), "STR_STAGE_S12_TIME"),
    /* 1251 */
    STR_STAGE_S13_TIME(Integer.valueOf(9467), "STR_STAGE_S13_TIME"),
    /* 1252 */
    STR_STAGE_S14_TIME(Integer.valueOf(9468), "STR_STAGE_S14_TIME"),
    /* 1253 */
    STR_STAGE_S15_TIME(Integer.valueOf(9469), "STR_STAGE_S15_TIME"),
    /* 1254 */
    STR_STAGE_S16_TIME(Integer.valueOf(9470), "STR_STAGE_S16_TIME"),
    /* 1255 */
    STR_STAGE_S17_TIME(Integer.valueOf(9471), "STR_STAGE_S17_TIME"),
    /* 1256 */
    STR_STAGE_S18_TIME(Integer.valueOf(9472), "STR_STAGE_S18_TIME"),
    /* 1257 */
    STR_STAGE_S19_TIME(Integer.valueOf(9473), "STR_STAGE_S19_TIME"),
    /* 1258 */
    STR_STAGE_S20_TIME(Integer.valueOf(9474), "STR_STAGE_S20_TIME"),
    /* 1259 */
    STR_STAGE_S21_TIME(Integer.valueOf(9475), "STR_STAGE_S21_TIME"),
    /* 1260 */
    STR_STAGE_S22_TIME(Integer.valueOf(9476), "STR_STAGE_S22_TIME"),
    /* 1261 */
    STR_STAGE_S23_TIME(Integer.valueOf(9477), "STR_STAGE_S23_TIME"),
    /* 1262 */
    STR_STAGE_S24_TIME(Integer.valueOf(9478), "STR_STAGE_S24_TIME"),
    /*      */
    /* 1264 */
    SWITCH_DOSE_LMT_1H(Integer.valueOf(9479), "SWITCH_DOSE_LMT_1H"),
    /* 1265 */
    SWITCH_DOSE_LMT_2H(Integer.valueOf(9480), "SWITCH_DOSE_LMT_2H"),
    /* 1266 */
    SWITCH_DOSE_LMT_3H(Integer.valueOf(9481), "SWITCH_DOSE_LMT_3H"),
    /* 1267 */
    SWITCH_DOSE_LMT_4H(Integer.valueOf(9482), "SWITCH_DOSE_LMT_4H"),
    /* 1268 */
    SWITCH_DOSE_LMT_5H(Integer.valueOf(9483), "SWITCH_DOSE_LMT_5H"),
    /* 1269 */
    SWITCH_DOSE_LMT_6H(Integer.valueOf(9484), "SWITCH_DOSE_LMT_6H"),
    /* 1270 */
    SWITCH_DOSE_LMT_7H(Integer.valueOf(9485), "SWITCH_DOSE_LMT_7H"),
    /* 1271 */
    SWITCH_DOSE_LMT_8H(Integer.valueOf(9486), "SWITCH_DOSE_LMT_8H"),
    /* 1272 */
    SWITCH_DOSE_LMT_9H(Integer.valueOf(9487), "SWITCH_DOSE_LMT_9H"),
    /* 1273 */
    SWITCH_DOSE_LMT_10H(Integer.valueOf(9488), "SWITCH_DOSE_LMT_10H"),
    /* 1274 */
    SWITCH_DOSE_LMT_11H(Integer.valueOf(9489), "SWITCH_DOSE_LMT_11H"),
    /* 1275 */
    SWITCH_DOSE_LMT_12H(Integer.valueOf(9490), "SWITCH_DOSE_LMT_12H"),
    /* 1276 */
    SWITCH_DOSE_LMT_13H(Integer.valueOf(9491), "SWITCH_DOSE_LMT_13H"),
    /* 1277 */
    SWITCH_DOSE_LMT_14H(Integer.valueOf(9492), "SWITCH_DOSE_LMT_14H"),
    /* 1278 */
    SWITCH_DOSE_LMT_15H(Integer.valueOf(9493), "SWITCH_DOSE_LMT_15H"),
    /* 1279 */
    SWITCH_DOSE_LMT_16H(Integer.valueOf(9494), "SWITCH_DOSE_LMT_16H"),
    /* 1280 */
    SWITCH_DOSE_LMT_17H(Integer.valueOf(9495), "SWITCH_DOSE_LMT_17H"),
    /* 1281 */
    SWITCH_DOSE_LMT_18H(Integer.valueOf(9496), "SWITCH_DOSE_LMT_18H"),
    /* 1282 */
    SWITCH_DOSE_LMT_19H(Integer.valueOf(9497), "SWITCH_DOSE_LMT_19H"),
    /* 1283 */
    SWITCH_DOSE_LMT_20H(Integer.valueOf(9498), "SWITCH_DOSE_LMT_20H"),
    /* 1284 */
    SWITCH_DOSE_LMT_21H(Integer.valueOf(9499), "SWITCH_DOSE_LMT_21H"),
    /* 1285 */
    SWITCH_DOSE_LMT_22H(Integer.valueOf(9500), "SWITCH_DOSE_LMT_22H"),
    /* 1286 */
    SWITCH_DOSE_LMT_23H(Integer.valueOf(9501), "SWITCH_DOSE_LMT_23H"),
    /* 1287 */
    SWITCH_DOSE_LMT_24H(Integer.valueOf(9502), "SWITCH_DOSE_LMT_24H"),
    /*      */
    /* 1289 */
    DOSE_LIMIT_1H(Integer.valueOf(9503), "DOSE_LIMIT_1H"),
    /* 1290 */
    DOSE_LIMIT_2H(Integer.valueOf(9504), "DOSE_LIMIT_2H"),
    /* 1291 */
    DOSE_LIMIT_3H(Integer.valueOf(9505), "DOSE_LIMIT_3H"),
    /* 1292 */
    DOSE_LIMIT_4H(Integer.valueOf(9506), "DOSE_LIMIT_4H"),
    /* 1293 */
    DOSE_LIMIT_5H(Integer.valueOf(9507), "DOSE_LIMIT_5H"),
    /* 1294 */
    DOSE_LIMIT_6H(Integer.valueOf(9508), "DOSE_LIMIT_6H"),
    /* 1295 */
    DOSE_LIMIT_7H(Integer.valueOf(9509), "DOSE_LIMIT_7H"),
    /* 1296 */
    DOSE_LIMIT_8H(Integer.valueOf(9510), "DOSE_LIMIT_8H"),
    /* 1297 */
    DOSE_LIMIT_9H(Integer.valueOf(9511), "DOSE_LIMIT_9H"),
    /* 1298 */
    DOSE_LIMIT_10H(Integer.valueOf(9512), "DOSE_LIMIT_10H"),
    /* 1299 */
    DOSE_LIMIT_11H(Integer.valueOf(9513), "DOSE_LIMIT_11H"),
    /* 1300 */
    DOSE_LIMIT_12H(Integer.valueOf(9514), "DOSE_LIMIT_12H"),
    /* 1301 */
    DOSE_LIMIT_13H(Integer.valueOf(9515), "DOSE_LIMIT_13H"),
    /* 1302 */
    DOSE_LIMIT_14H(Integer.valueOf(9516), "DOSE_LIMIT_14H"),
    /* 1303 */
    DOSE_LIMIT_15H(Integer.valueOf(9517), "DOSE_LIMIT_15H"),
    /* 1304 */
    DOSE_LIMIT_16H(Integer.valueOf(9518), "DOSE_LIMIT_16H"),
    /* 1305 */
    DOSE_LIMIT_17H(Integer.valueOf(9519), "DOSE_LIMIT_17H"),
    /* 1306 */
    DOSE_LIMIT_18H(Integer.valueOf(9520), "DOSE_LIMIT_18H"),
    /* 1307 */
    DOSE_LIMIT_19H(Integer.valueOf(9521), "DOSE_LIMIT_19H"),
    /* 1308 */
    DOSE_LIMIT_20H(Integer.valueOf(9522), "DOSE_LIMIT_20H"),
    /* 1309 */
    DOSE_LIMIT_21H(Integer.valueOf(9523), "DOSE_LIMIT_21H"),
    /* 1310 */
    DOSE_LIMIT_22H(Integer.valueOf(9524), "DOSE_LIMIT_22H"),
    /* 1311 */
    DOSE_LIMIT_23H(Integer.valueOf(9525), "DOSE_LIMIT_23H"),
    /* 1312 */
    DOSE_LIMIT_24H(Integer.valueOf(9526), "DOSE_LIMIT_24H"),
    /*      */
    /* 1314 */
    STR_SEQUE_S1(Integer.valueOf(9527), "STR_SEQUE_S1"),
    /* 1315 */
    STR_SEQUE_S2(Integer.valueOf(9528), "STR_SEQUE_S2"),
    /* 1316 */
    STR_SEQUE_S3(Integer.valueOf(9529), "STR_SEQUE_S3"),
    /* 1317 */
    STR_SEQUE_S4(Integer.valueOf(9530), "STR_SEQUE_S4"),
    /* 1318 */
    STR_SEQUE_S5(Integer.valueOf(9531), "STR_SEQUE_S5"),
    /* 1319 */
    STR_SEQUE_S6(Integer.valueOf(9532), "STR_SEQUE_S6"),
    /* 1320 */
    STR_SEQUE_S7(Integer.valueOf(9533), "STR_SEQUE_S7"),
    /* 1321 */
    STR_SEQUE_S8(Integer.valueOf(9534), "STR_SEQUE_S8"),
    /* 1322 */
    STR_SEQUE_S9(Integer.valueOf(9535), "STR_SEQUE_S9"),
    /* 1323 */
    STR_SEQUE_S10(Integer.valueOf(9536), "STR_SEQUE_S10"),
    /*      */
    /* 1325 */
    STR_STAGE_S1(Integer.valueOf(9537), "STR_STAGE_S1"),
    /* 1326 */
    STR_STAGE_S2(Integer.valueOf(9538), "STR_STAGE_S2"),
    /* 1327 */
    STR_STAGE_S3(Integer.valueOf(9539), "STR_STAGE_S3"),
    /* 1328 */
    STR_STAGE_S4(Integer.valueOf(9540), "STR_STAGE_S4"),
    /* 1329 */
    STR_STAGE_S5(Integer.valueOf(9541), "STR_STAGE_S5"),
    /* 1330 */
    STR_STAGE_S6(Integer.valueOf(9542), "STR_STAGE_S6"),
    /* 1331 */
    STR_STAGE_S7(Integer.valueOf(9543), "STR_STAGE_S7"),
    /* 1332 */
    STR_STAGE_S8(Integer.valueOf(9544), "STR_STAGE_S8"),
    /* 1333 */
    STR_STAGE_S9(Integer.valueOf(9545), "STR_STAGE_S9"),
    /* 1334 */
    STR_STAGE_S10(Integer.valueOf(9546), "STR_STAGE_S10"),
    /* 1335 */
    STR_STAGE_S11(Integer.valueOf(9547), "STR_STAGE_S11"),
    /* 1336 */
    STR_STAGE_S12(Integer.valueOf(9548), "STR_STAGE_S12"),
    /* 1337 */
    STR_STAGE_S13(Integer.valueOf(9549), "STR_STAGE_S13"),
    /* 1338 */
    STR_STAGE_S14(Integer.valueOf(9550), "STR_STAGE_S14"),
    /* 1339 */
    STR_STAGE_S15(Integer.valueOf(9551), "STR_STAGE_S15"),
    /* 1340 */
    STR_STAGE_S16(Integer.valueOf(9552), "STR_STAGE_S16"),
    /* 1341 */
    STR_STAGE_S17(Integer.valueOf(9553), "STR_STAGE_S17"),
    /* 1342 */
    STR_STAGE_S18(Integer.valueOf(9554), "STR_STAGE_S18"),
    /* 1343 */
    STR_STAGE_S19(Integer.valueOf(9555), "STR_STAGE_S19"),
    /* 1344 */
    STR_STAGE_S20(Integer.valueOf(9556), "STR_STAGE_S20"),
    /* 1345 */
    STR_STAGE_S21(Integer.valueOf(9557), "STR_STAGE_S21"),
    /* 1346 */
    STR_STAGE_S22(Integer.valueOf(9558), "STR_STAGE_S22"),
    /* 1347 */
    STR_STAGE_S23(Integer.valueOf(9559), "STR_STAGE_S23"),
    /* 1348 */
    STR_STAGE_S24(Integer.valueOf(9560), "STR_STAGE_S24"),
    /*      */
    /* 1350 */
    CLEAR_STR_EVENT_ERR_211(Integer.valueOf(9561), "alarm_CLEAR_STR_EVENT_ERR_211"),
    /* 1351 */
    CLEAR_STR_EVENT_ERR_212(Integer.valueOf(9562), "alarm_CLEAR_STR_EVENT_ERR_212"),
    /* 1352 */
    CLEAR_STR_EVENT_ERR_300(Integer.valueOf(9563), "alarm_CLEAR_STR_EVENT_ERR_300"),
    /* 1353 */
    CLEAR_STR_EVENT_ERR_303(Integer.valueOf(9564), "alarm_CLEAR_STR_EVENT_ERR_303"),
    /* 1354 */
    CLEAR_STR_EVENT_ERR_304(Integer.valueOf(9565), "alarm_CLEAR_STR_EVENT_ERR_304"),
    /* 1355 */
    CLEAR_STR_EVENT_ERR_305(Integer.valueOf(9566), "alarm_CLEAR_STR_EVENT_ERR_305"),
    /* 1356 */
    CLEAR_STR_EVENT_ERR_400(Integer.valueOf(9567), "alarm_CLEAR_STR_EVENT_ERR_400"),
    /* 1357 */
    CLEAR_STR_EVENT_ERR_401(Integer.valueOf(9568), "alarm_CLEAR_STR_EVENT_ERR_401"),
    /* 1358 */
    CLEAR_STR_EVENT_ERR_403(Integer.valueOf(9569), "alarm_CLEAR_STR_EVENT_ERR_403"),
    /* 1359 */
    CLEAR_STR_ALARM_INFUSION_COMPLETE(Integer.valueOf(9570), "alarm_CLEAR_STR_ALARM_INFUSION_COMPLETE"),
    /* 1360 */
    CLEAR_STR_ALARM_INFUSION_COMPLETE_KVO_START(Integer.valueOf(9571), "alarm_CLEAR_STR_ALARM_INFUSION_COMPLETE_KVO_START"),
    /* 1361 */
    CLEAR_STR_ALARM_INFUSION_NEAR_COMPLETE(Integer.valueOf(9572), "alarm_CLEAR_STR_ALARM_INFUSION_NEAR_COMPLETE"),
    /* 1362 */
    CLEAR_STR_ALARM_NO_BAT(Integer.valueOf(9573), "alarm_CLEAR_STR_ALARM_NO_BAT"),
    /* 1363 */
    CLEAR_STR_ALARM_NO_ACPOWER(Integer.valueOf(9574), "alarm_CLEAR_STR_ALARM_NO_ACPOWER"),
    /* 1364 */
    CLEAR_STR_ALARM_NO_POWER(Integer.valueOf(9575), "alarm_CLEAR_STR_ALARM_NO_POWER"),
    /* 1365 */
    CLEAR_STR_ALARM_CASSETTE_DETACHED(Integer.valueOf(9576), "alarm_CLEAR_STR_ALARM_CASSETTE_DETACHED"),
    /* 1366 */
    CLEAR_STR_ALARM_RESERVOIR_UNLOCK(Integer.valueOf(9577), "alarm_CLEAR_STR_ALARM_RESERVOIR_UNLOCK"),
    /* 1367 */
    CLEAR_STR_ALARM_BUTTON_FAULT(Integer.valueOf(9578), "alarm_CLEAR_STR_ALARM_BUTTON_FAULT"),
    /* 1368 */
    CLEAR_STR_ALARM_FORGET_OPERATION(Integer.valueOf(9579), "alarm_CLEAR_STR_ALARM_FORGET_OPERATION"),
    /* 1369 */
    CLEAR_STR_ALARM_DOWNSTREAM_OCCL(Integer.valueOf(9580), "alarm_CLEAR_STR_ALARM_DOWNSTREAM_OCCL"),
    /* 1370 */
    CLEAR_STR_ALARM_UPSTREAM_OCCL(Integer.valueOf(9581), "alarm_CLEAR_STR_ALARM_UPSTREAM_OCCL"),
    /* 1371 */
    CLEAR_STR_ALARM_BUBBLE_EXIST(Integer.valueOf(9582), "alarm_CLEAR_STR_ALARM_BUBBLE_EXIST"),
    /* 1372 */
    CLEAR_STR_ALARM_STBY_END(Integer.valueOf(9583), "alarm_CLEAR_STR_ALARM_STBY_END"),
    /* 1373 */
    CLEAR_STR_ALARM_PCA_DOSE_CONTROLLER_REMOVE(Integer.valueOf(9584), "alarm_CLEAR_STR_ALARM_PCA_DOSE_CONTROLLER_REMOVE"),
    /* 1374 */
    CLEAR_STR_ALARM_COM_INTERRUPTED(Integer.valueOf(9585), "alarm_CLEAR_STR_ALARM_COM_INTERRUPTED"),
    /* 1375 */
    CLEAR_STR_ALARM_BAT_EMPTY(Integer.valueOf(9586), "alarm_CLEAR_STR_ALARM_BAT_EMPTY"),
    /* 1376 */
    CLEAR_STR_ALARM_BAT_LOW(Integer.valueOf(9587), "alarm_CLEAR_STR_ALARM_BAT_LOW"),
    /* 1377 */
    CLEAR_STR_VTBI_LIMIT_EXC(Integer.valueOf(9588), "alarm_CLEAR_STR_VTBI_LIMIT_EXC"),
    /* 1378 */
    CLEAR_STR_EVENT_ERR_407(Integer.valueOf(9589), "alarm_CLEAR_STR_EVENT_ERR_407"),
    /* 1379 */
    CLEAR_MODERATE_PAIN(Integer.valueOf(9590), "alarm_CLEAR_MODERATE_PAIN"),
    /* 1380 */
    CLEAR_SEVERE_PAIN(Integer.valueOf(9591), "alarm_CLEAR_SEVERE_PAIN"),
    /* 1381 */
    CLEAR_INSUFFICIENT_ANALGESIA(Integer.valueOf(9592), "alarm_CLEAR_INSUFFICIENT_ANALGESIA"),
    /* 1382 */
    CLEAR_EXCESSIVE_ANALGESIA(Integer.valueOf(9593), "alarm_CLEAR_EXCESSIVE_ANALGESIA"),
    /* 1383 */
    CLEAR_STR_PARAM_NOT_SAVED(Integer.valueOf(9594), "alarm_CLEAR_STR_PARAM_NOT_SAVED"),
    /* 1384 */
    CLEAR_STR_EVENT_ERR_301(Integer.valueOf(9595), "alarm_CLEAR_STR_EVENT_ERR_301"),
    /* 1385 */
    CLEAR_STR_ERR_408(Integer.valueOf(9596), "alarm_CLEAR_STR_ERR_408"),
    /* 1386 */
    CLEAR_STR_EVENT_ERR_99(Integer.valueOf(9597), "alarm_CLEAR_STR_EVENT_ERR_99"),
    /* 1387 */
    CLEAR_STR_EVENT_ERR_100(Integer.valueOf(9598), "alarm_CLEAR_STR_EVENT_ERR_100"),
    /* 1388 */
    CLEAR_STR_EVENT_ERR_101(Integer.valueOf(9599), "alarm_CLEAR_STR_EVENT_ERR_101"),
    /* 1389 */
    CLEAR_STR_EVENT_ERR_103(Integer.valueOf(9600), "alarm_CLEAR_STR_EVENT_ERR_103"),
    /* 1390 */
    CLEAR_STR_EVENT_ERR_200(Integer.valueOf(9601), "alarm_CLEAR_STR_EVENT_ERR_200"),
    /* 1391 */
    CLEAR_STR_EVENT_ERR_201(Integer.valueOf(9602), "alarm_CLEAR_STR_EVENT_ERR_201"),
    /* 1392 */
    CLEAR_STR_EVENT_ERR_202(Integer.valueOf(9603), "alarm_CLEAR_STR_EVENT_ERR_202"),
    /* 1393 */
    CLEAR_STR_EVENT_ERR_203(Integer.valueOf(9604), "alarm_CLEAR_STR_EVENT_ERR_203"),
    /* 1394 */
    CLEAR_STR_EVENT_ERR_204(Integer.valueOf(9605), "alarm_CLEAR_STR_EVENT_ERR_204"),
    /* 1395 */
    CLEAR_STR_EVENT_ERR_205(Integer.valueOf(9606), "alarm_CLEAR_STR_EVENT_ERR_205"),
    /* 1396 */
    CLEAR_STR_EVENT_ERR_208(Integer.valueOf(9607), "alarm_CLEAR_STR_EVENT_ERR_208"),
    /* 1397 */
    CLEAR_STR_EVENT_ERR_209(Integer.valueOf(9608), "alarm_CLEAR_STR_EVENT_ERR_209"),
    /* 1398 */
    CLEAR_STR_EVENT_ERR_210(Integer.valueOf(9609), "alarm_CLEAR_STR_EVENT_ERR_210"),
    /*      */
    /* 1400 */
    LEVEL_STR_EVENT_ERR_211(Integer.valueOf(9610), "alarm_LEVEL_STR_EVENT_ERR_211"),
    /* 1401 */
    LEVEL_STR_EVENT_ERR_212(Integer.valueOf(9611), "alarm_LEVEL_STR_EVENT_ERR_212"),
    /* 1402 */
    LEVEL_STR_EVENT_ERR_300(Integer.valueOf(9612), "alarm_LEVEL_STR_EVENT_ERR_300"),
    /* 1403 */
    LEVEL_STR_EVENT_ERR_303(Integer.valueOf(9613), "alarm_LEVEL_STR_EVENT_ERR_303"),
    /* 1404 */
    LEVEL_STR_EVENT_ERR_304(Integer.valueOf(9614), "alarm_LEVEL_STR_EVENT_ERR_304"),
    /* 1405 */
    LEVEL_STR_EVENT_ERR_305(Integer.valueOf(9615), "alarm_LEVEL_STR_EVENT_ERR_305"),
    /* 1406 */
    LEVEL_STR_EVENT_ERR_400(Integer.valueOf(9616), "alarm_LEVEL_STR_EVENT_ERR_400"),
    /* 1407 */
    LEVEL_STR_EVENT_ERR_401(Integer.valueOf(9617), "alarm_LEVEL_STR_EVENT_ERR_401"),
    /* 1408 */
    LEVEL_STR_EVENT_ERR_403(Integer.valueOf(9618), "alarm_LEVEL_STR_EVENT_ERR_403"),
    /* 1409 */
    LEVEL_STR_ALARM_INFUSION_COMPLETE(Integer.valueOf(9619), "alarm_LEVEL_STR_ALARM_INFUSION_COMPLETE"),
    /* 1410 */
    LEVEL_STR_ALARM_INFUSION_COMPLETE_KVO_START(Integer.valueOf(9620), "alarm_LEVEL_STR_ALARM_INFUSION_COMPLETE_KVO_START"),
    /* 1411 */
    LEVEL_STR_ALARM_INFUSION_NEAR_COMPLETE(Integer.valueOf(9621), "alarm_LEVEL_STR_ALARM_INFUSION_NEAR_COMPLETE"),
    /* 1412 */
    LEVEL_STR_ALARM_NO_BAT(Integer.valueOf(9622), "alarm_LEVEL_STR_ALARM_NO_BAT"),
    /* 1413 */
    LEVEL_STR_ALARM_NO_ACPOWER(Integer.valueOf(9623), "alarm_LEVEL_STR_ALARM_NO_ACPOWER"),
    /* 1414 */
    LEVEL_STR_ALARM_NO_POWER(Integer.valueOf(9624), "alarm_LEVEL_STR_ALARM_NO_POWER"),
    /* 1415 */
    LEVEL_STR_ALARM_CASSETTE_DETACHED(Integer.valueOf(9625), "alarm_LEVEL_STR_ALARM_CASSETTE_DETACHED"),
    /* 1416 */
    LEVEL_STR_ALARM_RESERVOIR_UNLOCK(Integer.valueOf(9626), "alarm_LEVEL_STR_ALARM_RESERVOIR_UNLOCK"),
    /* 1417 */
    LEVEL_STR_ALARM_BUTTON_FAULT(Integer.valueOf(9627), "alarm_LEVEL_STR_ALARM_BUTTON_FAULT"),
    /* 1418 */
    LEVEL_STR_ALARM_FORGET_OPERATION(Integer.valueOf(9628), "alarm_LEVEL_STR_ALARM_FORGET_OPERATION"),
    /* 1419 */
    LEVEL_STR_ALARM_DOWNSTREAM_OCCL(Integer.valueOf(9629), "alarm_LEVEL_STR_ALARM_DOWNSTREAM_OCCL"),
    /* 1420 */
    LEVEL_STR_ALARM_UPSTREAM_OCCL(Integer.valueOf(9630), "alarm_LEVEL_STR_ALARM_UPSTREAM_OCCL"),
    /* 1421 */
    LEVEL_STR_ALARM_BUBBLE_EXIST(Integer.valueOf(9631), "alarm_LEVEL_STR_ALARM_BUBBLE_EXIST"),
    /* 1422 */
    LEVEL_STR_ALARM_STBY_END(Integer.valueOf(9632), "alarm_LEVEL_STR_ALARM_STBY_END"),
    /* 1423 */
    LEVEL_STR_ALARM_PCA_DOSE_CONTROLLER_REMOVE(Integer.valueOf(9633), "alarm_LEVEL_STR_ALARM_PCA_DOSE_CONTROLLER_REMOVE"),
    /* 1424 */
    LEVEL_STR_ALARM_COM_INTERRUPTED(Integer.valueOf(9634), "alarm_LEVEL_STR_ALARM_COM_INTERRUPTED"),
    /* 1425 */
    LEVEL_STR_ALARM_BAT_EMPTY(Integer.valueOf(9635), "alarm_LEVEL_STR_ALARM_BAT_EMPTY"),
    /* 1426 */
    LEVEL_STR_ALARM_BAT_LOW(Integer.valueOf(9636), "alarm_LEVEL_STR_ALARM_BAT_LOW"),
    /* 1427 */
    LEVEL_STR_VTBI_LIMIT_EXC(Integer.valueOf(9637), "alarm_LEVEL_STR_VTBI_LIMIT_EXC"),
    /* 1428 */
    LEVEL_STR_EVENT_ERR_407(Integer.valueOf(9638), "alarm_LEVEL_STR_EVENT_ERR_407"),
    /* 1429 */
    LEVEL_MODERATE_PAIN(Integer.valueOf(9639), "alarm_LEVEL_MODERATE_PAIN"),
    /* 1430 */
    LEVEL_SEVERE_PAIN(Integer.valueOf(9640), "alarm_LEVEL_SEVERE_PAIN"),
    /* 1431 */
    LEVEL_INSUFFICIENT_ANALGESIA(Integer.valueOf(9641), "alarm_LEVEL_INSUFFICIENT_ANALGESIA"),
    /* 1432 */
    LEVEL_EXCESSIVE_ANALGESIA(Integer.valueOf(9642), "alarm_LEVEL_EXCESSIVE_ANALGESIA"),
    /* 1433 */
    LEVEL_STR_PARAM_NOT_SAVED(Integer.valueOf(9643), "alarm_LEVEL_STR_PARAM_NOT_SAVED"),
    /* 1434 */
    LEVEL_STR_EVENT_ERR_301(Integer.valueOf(9644), "alarm_LEVEL_STR_EVENT_ERR_301"),
    /* 1435 */
    LEVEL_STR_ERR_408(Integer.valueOf(9645), "alarm_LEVEL_STR_ERR_408"),
    /* 1436 */
    LEVEL_STR_EVENT_ERR_99(Integer.valueOf(9646), "alarm_LEVEL_STR_EVENT_ERR_99"),
    /* 1437 */
    LEVEL_STR_EVENT_ERR_100(Integer.valueOf(9647), "alarm_LEVEL_STR_EVENT_ERR_100"),
    /* 1438 */
    LEVEL_STR_EVENT_ERR_101(Integer.valueOf(9648), "alarm_LEVEL_STR_EVENT_ERR_101"),
    /* 1439 */
    LEVEL_STR_EVENT_ERR_103(Integer.valueOf(9649), "alarm_LEVEL_STR_EVENT_ERR_103"),
    /* 1440 */
    LEVEL_STR_EVENT_ERR_200(Integer.valueOf(9650), "alarm_LEVEL_STR_EVENT_ERR_200"),
    /* 1441 */
    LEVEL_STR_EVENT_ERR_201(Integer.valueOf(9651), "alarm_LEVEL_STR_EVENT_ERR_201"),
    /* 1442 */
    LEVEL_STR_EVENT_ERR_202(Integer.valueOf(9652), "alarm_LEVEL_STR_EVENT_ERR_202"),
    /* 1443 */
    LEVEL_STR_EVENT_ERR_203(Integer.valueOf(9653), "alarm_LEVEL_STR_EVENT_ERR_203"),
    /* 1444 */
    LEVEL_STR_EVENT_ERR_204(Integer.valueOf(9654), "alarm_LEVEL_STR_EVENT_ERR_204"),
    /* 1445 */
    LEVEL_STR_EVENT_ERR_205(Integer.valueOf(9655), "alarm_LEVEL_STR_EVENT_ERR_205"),
    /* 1446 */
    LEVEL_STR_EVENT_ERR_208(Integer.valueOf(9656), "alarm_LEVEL_STR_EVENT_ERR_208"),
    /* 1447 */
    LEVEL_STR_EVENT_ERR_209(Integer.valueOf(9657), "alarm_LEVEL_STR_EVENT_ERR_209"),
    /* 1448 */
    LEVEL_STR_EVENT_ERR_210(Integer.valueOf(9658), "alarm_LEVEL_STR_EVENT_ERR_210"),
    /* 1449 */
    PIEB_DOSE_MODE_SOFT_MIN_EXCEED(Integer.valueOf(9659), "PIEB_DOSE_MODE_SOFT_MIN_EXCEED"),
    /* 1450 */
    PIEB_DOSE_MODE_SOFT_MAX_EXCEED(Integer.valueOf(9660), "PIEB_DOSE_MODE_SOFT_MAX_EXCEED"),
    /* 1451 */
    PIEB_DOSE_MODE_HARD_MIN_EXCEED(Integer.valueOf(9661), "PIEB_DOSE_MODE_HARD_MIN_EXCEED"),
    /* 1452 */
    PIEB_DOSE_MODE_HARD_MAX_EXCEED(Integer.valueOf(9662), "PIEB_DOSE_MODE_HARD_MAX_EXCEED"),
    /*      */
    /* 1454 */
    STR_MODE_BOLUS_RATE(Integer.valueOf(9664), "STR_MODE_BOLUS_RATE"),
    /* 1455 */
    STR_MODE_BOLUS_VTBI(Integer.valueOf(9665), "STR_MODE_BOLUS_VTBI"),
    /* 1456 */
    STR_MODE_BOLUS_TIME(Integer.valueOf(9666), "STR_MODE_BOLUS_TIME"),
    /* 1457 */
    STR_MODE_BOLUS_DOSE(Integer.valueOf(9667), "STR_MODE_BOLUS_DOSE"),
    /*      */
    /* 1459 */
    HEIGHT_HARD_MIN_EXCEED(Integer.valueOf(9668), "HEIGHT_HARD_MIN_EXCEED"),
    /* 1460 */
    WEIGHT_HARD_MIN_EXCEED(Integer.valueOf(9669), "WEIGHT_HARD_MIN_EXCEED"),
    /*      */
    /* 1462 */
    LMT_DOSE_SOFT_MIN_EXCEED_2H(Integer.valueOf(9670), "LMT_DOSE_SOFT_MIN_EXCEED_2H"),
    /* 1463 */
    LMT_DOSE_SOFT_MAX_EXCEED_2H(Integer.valueOf(9671), "LMT_DOSE_SOFT_MAX_EXCEED_2H"),
    /* 1464 */
    LMT_DOSE_HARD_MIN_EXCEED_2H(Integer.valueOf(9672), "LMT_DOSE_HARD_MIN_EXCEED_2H"),
    /* 1465 */
    LMT_DOSE_SOFT_MIN_EXCEED_3H(Integer.valueOf(9673), "LMT_DOSE_SOFT_MIN_EXCEED_3H"),
    /* 1466 */
    LMT_DOSE_SOFT_MAX_EXCEED_3H(Integer.valueOf(9674), "LMT_DOSE_SOFT_MAX_EXCEED_3H"),
    /* 1467 */
    LMT_DOSE_HARD_MIN_EXCEED_3H(Integer.valueOf(9675), "LMT_DOSE_HARD_MIN_EXCEED_3H"),
    /* 1468 */
    LMT_DOSE_SOFT_MIN_EXCEED_4H(Integer.valueOf(9676), "LMT_DOSE_SOFT_MIN_EXCEED_4H"),
    /* 1469 */
    LMT_DOSE_SOFT_MAX_EXCEED_4H(Integer.valueOf(9677), "LMT_DOSE_SOFT_MAX_EXCEED_4H"),
    /* 1470 */
    LMT_DOSE_HARD_MIN_EXCEED_4H(Integer.valueOf(9678), "LMT_DOSE_HARD_MIN_EXCEED_4H"),
    /* 1471 */
    LMT_DOSE_SOFT_MIN_EXCEED_5H(Integer.valueOf(9679), "LMT_DOSE_SOFT_MIN_EXCEED_5H"),
    /* 1472 */
    LMT_DOSE_SOFT_MAX_EXCEED_5H(Integer.valueOf(9680), "LMT_DOSE_SOFT_MAX_EXCEED_5H"),
    /* 1473 */
    LMT_DOSE_HARD_MIN_EXCEED_5H(Integer.valueOf(9681), "LMT_DOSE_HARD_MIN_EXCEED_5H"),
    /* 1474 */
    LMT_DOSE_SOFT_MIN_EXCEED_6H(Integer.valueOf(9682), "LMT_DOSE_SOFT_MIN_EXCEED_6H"),
    /* 1475 */
    LMT_DOSE_SOFT_MAX_EXCEED_6H(Integer.valueOf(9683), "LMT_DOSE_SOFT_MAX_EXCEED_6H"),
    /* 1476 */
    LMT_DOSE_HARD_MIN_EXCEED_6H(Integer.valueOf(9684), "LMT_DOSE_HARD_MIN_EXCEED_6H"),
    /* 1477 */
    LMT_DOSE_SOFT_MIN_EXCEED_7H(Integer.valueOf(9685), "LMT_DOSE_SOFT_MIN_EXCEED_7H"),
    /* 1478 */
    LMT_DOSE_SOFT_MAX_EXCEED_7H(Integer.valueOf(9686), "LMT_DOSE_SOFT_MAX_EXCEED_7H"),
    /* 1479 */
    LMT_DOSE_HARD_MIN_EXCEED_7H(Integer.valueOf(9687), "LMT_DOSE_HARD_MIN_EXCEED_7H"),
    /* 1480 */
    LMT_DOSE_SOFT_MIN_EXCEED_8H(Integer.valueOf(9688), "LMT_DOSE_SOFT_MIN_EXCEED_8H"),
    /* 1481 */
    LMT_DOSE_SOFT_MAX_EXCEED_8H(Integer.valueOf(9689), "LMT_DOSE_SOFT_MAX_EXCEED_8H"),
    /* 1482 */
    LMT_DOSE_HARD_MIN_EXCEED_8H(Integer.valueOf(9690), "LMT_DOSE_HARD_MIN_EXCEED_8H"),
    /* 1483 */
    LMT_DOSE_SOFT_MIN_EXCEED_9H(Integer.valueOf(9691), "LMT_DOSE_SOFT_MIN_EXCEED_9H"),
    /* 1484 */
    LMT_DOSE_SOFT_MAX_EXCEED_9H(Integer.valueOf(9692), "LMT_DOSE_SOFT_MAX_EXCEED_9H"),
    /* 1485 */
    LMT_DOSE_HARD_MIN_EXCEED_9H(Integer.valueOf(9693), "LMT_DOSE_HARD_MIN_EXCEED_9H"),
    /* 1486 */
    LMT_DOSE_SOFT_MIN_EXCEED_10H(Integer.valueOf(9694), "10H_LMT_DOSE_SOFT_MIN_EXCEED_10H"),
    /* 1487 */
    LMT_DOSE_SOFT_MAX_EXCEED_10H(Integer.valueOf(9695), "10H_LMT_DOSE_SOFT_MAX_EXCEED_10H"),
    /* 1488 */
    LMT_DOSE_HARD_MIN_EXCEED_10H(Integer.valueOf(9696), "10H_LMT_DOSE_HARD_MIN_EXCEED_10H"),
    /* 1489 */
    LMT_DOSE_SOFT_MIN_EXCEED_11H(Integer.valueOf(9697), "11H_LMT_DOSE_SOFT_MIN_EXCEED_11H"),
    /* 1490 */
    LMT_DOSE_SOFT_MAX_EXCEED_11H(Integer.valueOf(9698), "11H_LMT_DOSE_SOFT_MAX_EXCEED_11H"),
    /* 1491 */
    LMT_DOSE_HARD_MIN_EXCEED_11H(Integer.valueOf(9699), "11H_LMT_DOSE_HARD_MIN_EXCEED_11H"),
    /* 1492 */
    LMT_DOSE_SOFT_MIN_EXCEED_12H(Integer.valueOf(9700), "12H_LMT_DOSE_SOFT_MIN_EXCEED_12H"),
    /* 1493 */
    LMT_DOSE_SOFT_MAX_EXCEED_12H(Integer.valueOf(9701), "12H_LMT_DOSE_SOFT_MAX_EXCEED_12H"),
    /* 1494 */
    LMT_DOSE_HARD_MIN_EXCEED_12H(Integer.valueOf(9702), "12H_LMT_DOSE_HARD_MIN_EXCEED_12H"),
    /* 1495 */
    LMT_DOSE_SOFT_MIN_EXCEED_13H(Integer.valueOf(9703), "13H_LMT_DOSE_SOFT_MIN_EXCEED_13H"),
    /* 1496 */
    LMT_DOSE_SOFT_MAX_EXCEED_13H(Integer.valueOf(9704), "13H_LMT_DOSE_SOFT_MAX_EXCEED_13H"),
    /* 1497 */
    LMT_DOSE_HARD_MIN_EXCEED_13H(Integer.valueOf(9705), "13H_LMT_DOSE_HARD_MIN_EXCEED_13H"),
    /* 1498 */
    LMT_DOSE_SOFT_MIN_EXCEED_14H(Integer.valueOf(9706), "14H_LMT_DOSE_SOFT_MIN_EXCEED_14H"),
    /* 1499 */
    LMT_DOSE_SOFT_MAX_EXCEED_14H(Integer.valueOf(9707), "14H_LMT_DOSE_SOFT_MAX_EXCEED_14H"),
    /* 1500 */
    LMT_DOSE_HARD_MIN_EXCEED_14H(Integer.valueOf(9708), "14H_LMT_DOSE_HARD_MIN_EXCEED_14H"),
    /* 1501 */
    LMT_DOSE_SOFT_MIN_EXCEED_15H(Integer.valueOf(9709), "15H_LMT_DOSE_SOFT_MIN_EXCEED_15H"),
    /* 1502 */
    LMT_DOSE_SOFT_MAX_EXCEED_15H(Integer.valueOf(9710), "15H_LMT_DOSE_SOFT_MAX_EXCEED_15H"),
    /* 1503 */
    LMT_DOSE_HARD_MIN_EXCEED_15H(Integer.valueOf(9711), "15H_LMT_DOSE_HARD_MIN_EXCEED_15H"),
    /* 1504 */
    LMT_DOSE_SOFT_MIN_EXCEED_16H(Integer.valueOf(9712), "16H_LMT_DOSE_SOFT_MIN_EXCEED_16H"),
    /* 1505 */
    LMT_DOSE_SOFT_MAX_EXCEED_16H(Integer.valueOf(9713), "16H_LMT_DOSE_SOFT_MAX_EXCEED_16H"),
    /* 1506 */
    LMT_DOSE_HARD_MIN_EXCEED_16H(Integer.valueOf(9714), "16H_LMT_DOSE_HARD_MIN_EXCEED_16H"),
    /* 1507 */
    LMT_DOSE_SOFT_MIN_EXCEED_17H(Integer.valueOf(9715), "17H_LMT_DOSE_SOFT_MIN_EXCEED_17H"),
    /* 1508 */
    LMT_DOSE_SOFT_MAX_EXCEED_17H(Integer.valueOf(9716), "17H_LMT_DOSE_SOFT_MAX_EXCEED_17H"),
    /* 1509 */
    LMT_DOSE_HARD_MIN_EXCEED_17H(Integer.valueOf(9717), "17H_LMT_DOSE_HARD_MIN_EXCEED_17H"),
    /* 1510 */
    LMT_DOSE_SOFT_MIN_EXCEED_18H(Integer.valueOf(9718), "18H_LMT_DOSE_SOFT_MIN_EXCEED_18H"),
    /* 1511 */
    LMT_DOSE_SOFT_MAX_EXCEED_18H(Integer.valueOf(9719), "18H_LMT_DOSE_SOFT_MAX_EXCEED_18H"),
    /* 1512 */
    LMT_DOSE_HARD_MIN_EXCEED_18H(Integer.valueOf(9720), "18H_LMT_DOSE_HARD_MIN_EXCEED_18H"),
    /* 1513 */
    LMT_DOSE_SOFT_MIN_EXCEED_19H(Integer.valueOf(9721), "19H_LMT_DOSE_SOFT_MIN_EXCEED_19H"),
    /* 1514 */
    LMT_DOSE_SOFT_MAX_EXCEED_19H(Integer.valueOf(9722), "19H_LMT_DOSE_SOFT_MAX_EXCEED_19H"),
    /* 1515 */
    LMT_DOSE_HARD_MIN_EXCEED_19H(Integer.valueOf(9723), "19H_LMT_DOSE_HARD_MIN_EXCEED_19H"),
    /* 1516 */
    LMT_DOSE_SOFT_MIN_EXCEED_20H(Integer.valueOf(9724), "20H_LMT_DOSE_SOFT_MIN_EXCEED_20H"),
    /* 1517 */
    LMT_DOSE_SOFT_MAX_EXCEED_20H(Integer.valueOf(9725), "20H_LMT_DOSE_SOFT_MAX_EXCEED_20H"),
    /* 1518 */
    LMT_DOSE_HARD_MIN_EXCEED_20H(Integer.valueOf(9726), "20H_LMT_DOSE_HARD_MIN_EXCEED_20H"),
    /* 1519 */
    LMT_DOSE_SOFT_MIN_EXCEED_21H(Integer.valueOf(9727), "21H_LMT_DOSE_SOFT_MIN_EXCEED_21H"),
    /* 1520 */
    LMT_DOSE_SOFT_MAX_EXCEED_21H(Integer.valueOf(9728), "21H_LMT_DOSE_SOFT_MAX_EXCEED_21H"),
    /* 1521 */
    LMT_DOSE_HARD_MIN_EXCEED_21H(Integer.valueOf(9729), "21H_LMT_DOSE_HARD_MIN_EXCEED_21H"),
    /* 1522 */
    LMT_DOSE_SOFT_MIN_EXCEED_22H(Integer.valueOf(9730), "22H_LMT_DOSE_SOFT_MIN_EXCEED_22H"),
    /* 1523 */
    LMT_DOSE_SOFT_MAX_EXCEED_22H(Integer.valueOf(9731), "22H_LMT_DOSE_SOFT_MAX_EXCEED_22H"),
    /* 1524 */
    LMT_DOSE_HARD_MIN_EXCEED_22H(Integer.valueOf(9732), "22H_LMT_DOSE_HARD_MIN_EXCEED_22H"),
    /* 1525 */
    LMT_DOSE_SOFT_MIN_EXCEED_23H(Integer.valueOf(9733), "23H_LMT_DOSE_SOFT_MIN_EXCEED_23H"),
    /* 1526 */
    LMT_DOSE_SOFT_MAX_EXCEED_23H(Integer.valueOf(9734), "23H_LMT_DOSE_SOFT_MAX_EXCEED_23H"),
    /* 1527 */
    LMT_DOSE_HARD_MIN_EXCEED_23H(Integer.valueOf(9735), "23H_LMT_DOSE_HARD_MIN_EXCEED_23H"),
    /* 1528 */
    LMT_DOSE_SOFT_MIN_EXCEED_24H(Integer.valueOf(9736), "24H_LMT_DOSE_SOFT_MIN_EXCEED_24H"),
    /* 1529 */
    LMT_DOSE_SOFT_MAX_EXCEED_24H(Integer.valueOf(9737), "24H_LMT_DOSE_SOFT_MAX_EXCEED_24H"),
    /* 1530 */
    LMT_DOSE_HARD_MIN_EXCEED_24H(Integer.valueOf(9738), "24H_LMT_DOSE_HARD_MIN_EXCEED_24H"),
    /*      */
    /* 1532 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_2H(Integer.valueOf(9739), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_2H"),
    /* 1533 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_2H(Integer.valueOf(9740), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_2H"),
    /* 1534 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_2H(Integer.valueOf(9741), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_2H"),
    /* 1535 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_3H(Integer.valueOf(9742), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_3H"),
    /* 1536 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_3H(Integer.valueOf(9743), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_3H"),
    /* 1537 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_3H(Integer.valueOf(9744), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_3H"),
    /* 1538 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_4H(Integer.valueOf(9745), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_4H"),
    /* 1539 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_4H(Integer.valueOf(9746), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_4H"),
    /* 1540 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_4H(Integer.valueOf(9747), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_4H"),
    /* 1541 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_5H(Integer.valueOf(9748), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_5H"),
    /* 1542 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_5H(Integer.valueOf(9749), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_5H"),
    /* 1543 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_5H(Integer.valueOf(9750), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_5H"),
    /* 1544 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_6H(Integer.valueOf(9751), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_6H"),
    /* 1545 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_6H(Integer.valueOf(9752), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_6H"),
    /* 1546 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_6H(Integer.valueOf(9753), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_6H"),
    /* 1547 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_7H(Integer.valueOf(9754), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_7H"),
    /* 1548 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_7H(Integer.valueOf(9755), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_7H"),
    /* 1549 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_7H(Integer.valueOf(9756), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_7H"),
    /* 1550 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_8H(Integer.valueOf(9757), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_8H"),
    /* 1551 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_8H(Integer.valueOf(9758), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_8H"),
    /* 1552 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_8H(Integer.valueOf(9759), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_8H"),
    /* 1553 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_9H(Integer.valueOf(9760), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_9H"),
    /* 1554 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_9H(Integer.valueOf(9761), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_9H"),
    /* 1555 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_9H(Integer.valueOf(9762), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_9H"),
    /* 1556 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_10H(Integer.valueOf(9763), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_10H"),
    /* 1557 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_10H(Integer.valueOf(9764), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_10H"),
    /* 1558 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_10H(Integer.valueOf(9765), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_10H"),
    /* 1559 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_11H(Integer.valueOf(9766), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_11H"),
    /* 1560 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_11H(Integer.valueOf(9767), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_11H"),
    /* 1561 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_11H(Integer.valueOf(9768), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_11H"),
    /* 1562 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_12H(Integer.valueOf(9769), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_12H"),
    /* 1563 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_12H(Integer.valueOf(9770), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_12H"),
    /* 1564 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_12H(Integer.valueOf(9771), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_12H"),
    /* 1565 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_13H(Integer.valueOf(9772), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_13H"),
    /* 1566 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_13H(Integer.valueOf(9773), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_13H"),
    /* 1567 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_13H(Integer.valueOf(9774), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_13H"),
    /* 1568 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_14H(Integer.valueOf(9775), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_14H"),
    /* 1569 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_14H(Integer.valueOf(9776), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_14H"),
    /* 1570 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_14H(Integer.valueOf(9777), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_14H"),
    /* 1571 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_15H(Integer.valueOf(9778), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_15H"),
    /* 1572 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_15H(Integer.valueOf(9779), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_15H"),
    /* 1573 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_15H(Integer.valueOf(9780), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_15H"),
    /* 1574 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_16H(Integer.valueOf(9781), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_16H"),
    /* 1575 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_16H(Integer.valueOf(9782), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_16H"),
    /* 1576 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_16H(Integer.valueOf(9783), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_16H"),
    /* 1577 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_17H(Integer.valueOf(9784), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_17H"),
    /* 1578 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_17H(Integer.valueOf(9785), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_17H"),
    /* 1579 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_17H(Integer.valueOf(9786), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_17H"),
    /* 1580 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_18H(Integer.valueOf(9787), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_18H"),
    /* 1581 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_18H(Integer.valueOf(9788), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_18H"),
    /* 1582 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_18H(Integer.valueOf(9789), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_18H"),
    /* 1583 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_19H(Integer.valueOf(9790), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_19H"),
    /* 1584 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_19H(Integer.valueOf(9791), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_19H"),
    /* 1585 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_19H(Integer.valueOf(9792), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_19H"),
    /* 1586 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_20H(Integer.valueOf(9793), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_20H"),
    /* 1587 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_20H(Integer.valueOf(9794), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_20H"),
    /* 1588 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_20H(Integer.valueOf(9795), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_20H"),
    /* 1589 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_21H(Integer.valueOf(9796), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_21H"),
    /* 1590 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_21H(Integer.valueOf(9797), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_21H"),
    /* 1591 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_21H(Integer.valueOf(9798), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_21H"),
    /* 1592 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_22H(Integer.valueOf(9799), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_22H"),
    /* 1593 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_22H(Integer.valueOf(9800), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_22H"),
    /* 1594 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_22H(Integer.valueOf(9801), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_22H"),
    /* 1595 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_23H(Integer.valueOf(9802), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_23H"),
    /* 1596 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_23H(Integer.valueOf(9803), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_23H"),
    /* 1597 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_23H(Integer.valueOf(9804), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_23H"),
    /* 1598 */
    DOSE_LMT_DOSE_SOFT_MIN_EXCEED_24H(Integer.valueOf(9805), "DOSE_LMT_DOSE_SOFT_MIN_EXCEED_24H"),
    /* 1599 */
    DOSE_LMT_DOSE_SOFT_MAX_EXCEED_24H(Integer.valueOf(9806), "DOSE_LMT_DOSE_SOFT_MAX_EXCEED_24H"),
    /* 1600 */
    DOSE_LMT_DOSE_HARD_MIN_EXCEED_24H(Integer.valueOf(9807), "DOSE_LMT_DOSE_HARD_MIN_EXCEED_24H");
    /*      */
    /*      */
    LogEventIdEnum(Integer eventId, String key) {
/* 1603 */     this.eventId = eventId;
/* 1604 */     this.key = key;
    /*      */
}
/*      */
/*      */
/*      */
private final Integer eventId;
/*      */
/*      */
private String key;
/*      */
private static final String KEY_PRE = "pumpLog.";
/*      */
/*      */
public Integer getEventId()
{
    /* 1614 */
    return this.eventId;
    /*      */
}
/*      */
/*      */
public static com.medcaptain.icms.common.commonEnum.LogEventIdEnum getEnumById(Integer eventId)
{
    /* 1618 */
    for (com.medcaptain.icms.common.commonEnum.LogEventIdEnum logEventIdEnum : values()) {
    /* 1619 */
    if (Objects.equals(eventId, logEventIdEnum.getEventId()))
    {
        /* 1620 */
        return logEventIdEnum;
        /*      */
    }
    /*      */
}
/* 1623 */
return STR_NULL;
/*      */   }
/*      */   
/*      */   public static String getKey(Integer eventId)
{
    /* 1627 */
    return (getEnumById(eventId)).key.isEmpty() ? "" : ("pumpLog." + (getEnumById(eventId)).key);
    /*      */
}
/*      */
/*      */
public String getKey()
{
    /* 1631 */
    return "pumpLog." + this.key;
    /*      */
}
/*      */
/*      */
public static Integer queryInfusionModeByEventId(Integer eventId)
{
    /* 1635 */
    switch (null.$SwitchMap$com$medcaptain$icms$common$commonEnum$LogEventIdEnum[getEnumById(eventId).ordinal()]) {
/*      */       case 1:
            /* 1637 */
            return InfusionModeEnum.PCA.getType();
        /*      */
        case 2:
            /* 1639 */
            return InfusionModeEnum.PIEB.getType();
        /*      */
        case 3:
            /* 1641 */
            return InfusionModeEnum.PCEA.getType();
        /*      */
        case 4:
            /* 1643 */
            return InfusionModeEnum.PCS.getType();
        /*      */
        case 5:
            /* 1645 */
            return InfusionModeEnum.CHRO.getType();
        /*      */
        case 6:
            /* 1647 */
            return InfusionModeEnum.RATE.getType();
        /*      */
        case 7:
            /* 1649 */
            return InfusionModeEnum.TIME.getType();
        /*      */
        case 8:
            /* 1651 */
            return InfusionModeEnum.WEIGHT.getType();
        /*      */
        case 9:
            /* 1653 */
            return InfusionModeEnum.SEQUE.getType();
        /*      */
        case 10:
            /* 1655 */
            return InfusionModeEnum.LOAD.getType();
        /*      */
        case 11:
            /* 1657 */
            return InfusionModeEnum.INTER.getType();
        /*      */
        case 12:
            /* 1659 */
            return InfusionModeEnum.TRAPE.getType();
            /*      */
        }
        /* 1661 */
        return InfusionModeEnum.NONE_INFUSION_MODE.getType();
        /*      */
    }
/*      */
    /*      */
    /*      */
             public static Integer getEventIdByKey(String key)
{
    /* 1666 */
    for (com.medcaptain.icms.common.commonEnum.LogEventIdEnum logEventIdEnum : values()) {
    /* 1667 */
    if (Objects.equals(key, logEventIdEnum.getKey()))
    {
        /* 1668 */
        return logEventIdEnum.getEventId();
        /*      */
    }
    /*      */
}
/* 1671 */
return null;
/*      */   }
/*      */ }


/* Location:              C:\Users\balik\OneDrive\Desktop\icms\app\web_server.jar!\BOOT-INF\classes\com\medcaptain\icms\common\commonEnum\LogEventIdEnum.class
 * Java compiler version: 8 (52.0)
 * JD-Core Version:       1.1.3
 */