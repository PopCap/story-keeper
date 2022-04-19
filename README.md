# story-keeper
Story Keeper: D&amp;D 5e Note Taking Application

Current Schema:

![Story Keeper](https://user-images.githubusercontent.com/12686103/163897119-a740fa37-cf2e-41d5-b74b-b0a6dcfbb052.png)


Current Schema Text for (dbdiagram.io):

```
// tony journal ideal
// feature: 
// keep link system or not???
// character equipment based on equiped bool

// Creating tables
Table campaign {
  id int [pk, increment] // auto-increment
  name varchar
  dm varchar
  created_at timestamp
}

Table session {
  id int [pk, increment]
  camp_id int [ref: > campaign.id]
  session_date timestamp
}

Table session_note {
  id int [pk, increment]
  sess_id int [ref: > session.id]
  notes varchar
  note_time timestamp
}

Table tag {
  id int [pk, increment]
  sess_note_id int [ref: > session_note.id]
  name varchar
}

Table item_link {
  id int [pk, increment]
  inv_id int [ref: > inventory.id]
  item_id int [ref: > item.id]
  is_equipped bool
}

Table item {
  id int [pk, increment]
  source varchar
  name varchar
  value varchar
  category varchar //
  description varchar
  weight varchar
  req_att bool
  quantity int
}


Table location {
  id int [pk, increment]
  varchar name
}

Table location_link {
  id int [pk, increment]
  camp_id int [ref: > campaign.id]
  loc_id int [ref: > location.id]
}

Table location_info {
  id int [pk, increment]
  llink_id int [ref: > location_link.id]
  notes varchar
}

Table location_inventory_link {
  id int [pk, increment]
  linfo_id int [ref: > location_info.id]
  inv_id int [ref: > inventory.id]
}

Table location_tree {
  id int [pk, increment]
  parent_loc int [ref: > location.id]
  child_loc int [ref: > location.id]
}

Table location_npc {
  id int [pk, increment]
  linfo_if int [ref: > location_info.id]
  char_id int [ref: > character.id]
}

Table character_link {
  id int [pk, increment]
  camp_id int [ref: > campaign.id]
  char_id int [ref: > character.id]
}

Table character {
  id int [pk, increment]
  name varchar
  is_player bool
  is_active bool
}

Table character_association {
  id int [pk, increment]
  relation varchar
  char_from int [ref: > character.id]
  char_to int [ref: > character.id]
}

Table character_skills {
  id int [pk, increment]
  c_info int [ref: > character_info.id] 
  acrobatics int
  animal_handling int
  arcana int
  athletics int
  deception int
  history int
  insight int
  intimidation int
  investigation int
  medicine int
  nature int
  perception int
  performance int
  persuasion int
  religion int
  sleight_of_hand int
  stealth int //0 no, 1 prof, 2 exp
  survival int
  
}

Table character_saves {
  id int [pk, increment]
  cinfo_id int [ref: > character_info.id]
  strength bool
  dexterity bool
  constitution bool
  intelligence bool
  wisdom bool
  charisma bool
}

 
Table character_bio {
  id int [pk, increment]
  note varchar
  last_edit timestamp
  char_id int [ref: - character.id]
}

Table character_tag {
  id int [pk, increment]
  tag_id int [ref: > tag.id]
  char_id int [ref: > character_link.id]
}

Table location_tag {
  id int [pk, increment]
  tag_id int [ref: > tag.id]
  loc_id int [ref: > location.id]
}

Table organization_tag {
  id int [pk, increment]
  tag_id int [ref: > tag.id]
  org_id int [ref: > organization_link.id]
}
 
Table character_info {
 id int [pk, increment]
 char_id int [ref: > character.id]
 race varchar
 personality varchar
 bonds varchar
 ideals varchar
 level int
 class varchar
 background varchar
 alignment varchar
 strength int
 dexterity int
 constitution int
 intelligence int
 wisdom int
 charisma int
 proficiency int
 armor_class int
 initiative int
 speed int
}

Table character_health {
  id int [pk, increment]
  char_id int [ref: > character.id]
  hit_point_max int
  current_hit_points int
  temp_hit_points int
}

Table character_inventory_link {
 id int [pk, increment]
 char_id int [ref: - character.id]
 inv_id int [ref: < inventory.id]
}

Table character_spellsheet {
  id int [pk, increment]
  char_id int [ref: > character.id]
  spell_attack int
  spell_dc int
  class varchar
  zero_total int
  one_total int
  two_total int
  three_total int
  four_total int
  five_total int
  six_total int
  seven_total int
  eight_total int
  nine_total int
  above_total int
}



Table organization {
  id int [pk, increment]
  name varchar
  type varchar
}

Table organization_link {
  id int [pk, increment]
  org_id int [ref: > organization.id]
  camp_id int [ref: > campaign.id] 
}

Table organization_info {
  id int [pk, increment]
  orgl_id int [ref: > organization_link.id]
  info varchar
}

Table organization_membership {
  id int [pk, increment]
  role varchar
  char_id int [ref: > character.id]
  org_id int [ref: > organization.id]
}

Table organization_association {
  id int [pk, increment]
  relation varchar
  org_from int [ref: > organization_link.id]
  org_to int [ref: > organization_link.id]

}

Table spell {
  id int [pk, increment]
  name varchar
  school varchar
  level int
  cast_time varchar
  range varchar
  duration varchar
  componenets varchar
  source varchar
}

Table spell_link {
  int id [pk, increment]
  cspellsheet_id int [ref: > character_spellsheet.id]
  spell_id int [ref: > spell.id]
}

Table race_trait {
  id int [pk, increment]
  race varchar
  info varchar
}

Table rtrait_link {
  id int [pk, increment]
  char_id int [ref: > character.id]
  rtrait_id int [ref: > race_trait.id]
}

Table feat {
  id int [pk, increment]
  info varchar
}

Table feat_link {
  id int [pk, increment]
  char_id int [ref: > character.id]
  feat_id int [ref: > feat.id]
}

Table class_feature {
  id int [pk, increment]
  class varchar
  info varchar
}

Table class_feature_link {
  id int [pk, increment]
  char_id int [ref: > character.id]
  cfeature_id int [ref: > class_feature.id]
}

Table inventory {
  id int [pk, increment]
  name varchar
  items varchar
  equipment varchar
  platinum int
  gold int
  electrum int
  silver int
  copper int
  
}
```
