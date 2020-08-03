function PrepareString(s) {
    s = s.replace(/&/g, "_a_m_p_;_");
    s = s.replace(/\+/g, "_p_l_u_s_");
    return s;
}